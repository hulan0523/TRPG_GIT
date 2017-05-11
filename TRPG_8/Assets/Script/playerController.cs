using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerController : NetworkBehaviour
{

    private playerMove _playerMove;
    private Transform playerCameraTransform;
    private Camera playerCamera;
    private AudioListener playerAudioListener;
    // Use this for initialization
    public Canvas conversation;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLocalPlayer)
        {
            CmdSayHi();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (isLocalPlayer)
        {
            CmdDestroyHi();
        }
    }
    void Start()
    {
        if (isLocalPlayer)
        {
            gameObject.name = "ME";
        }
        //當角色被產生出來時，如果不是Local Player就把所有的控制項目關閉，這些角色的位置資料將由Server來同步
        if (!isLocalPlayer)
        {
            _playerMove = GetComponent<playerMove>();

            if (_playerMove)
            {
                _playerMove.enabled = false;
            }
        }
    }
    [Command]
    void CmdSayHi()
    {
            RpcSayHi();
    }
    [ClientRpc]
    void RpcSayHi()
    {
        conversation.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
        Instantiate(conversation);
    }
    [Command]
    void CmdDestroyHi()
    {
            RpcDestroyHi();
    }
    [ClientRpc]
    void RpcDestroyHi()
    {
        Destroy(GameObject.Find("HICanvas(Clone)"));
    }
}
