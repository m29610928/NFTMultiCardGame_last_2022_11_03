using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : UI_Base
{
    enum GameObjects
    {
        NameText,
        LobbyInfoText,
    }
    public TMP_Text nameText;
    public TMP_Text lobbyInfoText;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (Managers.Scene.CurrentScene.SceneType == Define.Scene.Lobby)
            SetLobbyInfoText("Lobby : " + (PhotonNetwork.CountOfPlayers - PhotonNetwork.CountOfPlayersInRooms) + " / Connected : " + PhotonNetwork.CountOfPlayers);
    }

    public override void Init()
    {
        
        Bind<GameObject>(typeof(GameObjects));

        nameText = Get<GameObject>((int)GameObjects.NameText).GetComponent<TMP_Text>();
        lobbyInfoText = Get<GameObject>((int)GameObjects.LobbyInfoText).GetComponent<TMP_Text>();

        //PhotonNetwork.LocalPlayer.NickName = NetworkManager.Login.NickNameInput.text;
        SetNameText("Name : " + PhotonNetwork.LocalPlayer.NickName);
    }

    public void SetNameText(string str)
    {
        nameText.text = str;
    }

    public void SetLobbyInfoText(string str)
    {
        lobbyInfoText.text = str;
    }


}
