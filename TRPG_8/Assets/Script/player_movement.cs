using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    Rigidbody2D rbody;
    Animator anim;

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NetworkView>().isMine)
        {
            InputMovement();
        }
        else
        {
            SyncedMovement();
        }
    }
    void InputMovement()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }
    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;
        GetComponent<Rigidbody2D>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }
    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = GetComponent<Rigidbody2D>().position;
            stream.Serialize(ref syncPosition);
        }
        else
        {
            stream.Serialize(ref syncPosition);

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncStartPosition = GetComponent<Rigidbody2D>().position;
            syncEndPosition = syncPosition;
        }
    }
}
