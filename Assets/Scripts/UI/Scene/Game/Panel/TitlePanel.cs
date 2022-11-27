using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : UI_Base
{
    enum GameObjects
    {
        StartButton,
    }

    PhotonView PV;

    public Button startButton;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        PV = GetComponent<PhotonView>();
        Bind<GameObject>(typeof(GameObjects));
        
        startButton = Get<GameObject>((int)GameObjects.StartButton).GetComponent<Button>();

        startButton.gameObject.BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            if(_GameManager.Inst.StartGame())
                PV.RPC("Active", RpcTarget.All, false);
        });
    }

    [PunRPC]
    public void Active(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

}
