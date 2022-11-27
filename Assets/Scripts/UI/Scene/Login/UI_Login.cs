using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : UI_Base
{
    enum GameObjects
    {
        PlayerName,
        LoginButton,
        ExitButton,
    }

    public InputField playerName;
    public Button loginButton;
    public Button exitButton;

    WalletLogin walletLogin;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        walletLogin = gameObject.GetComponent<WalletLogin>();

        Bind<GameObject>(typeof(GameObjects));

        playerName = Get<GameObject>((int)GameObjects.PlayerName).GetComponent<InputField>();
        loginButton = Get<GameObject>((int)GameObjects.LoginButton).GetComponent<Button>();
        exitButton = Get<GameObject>((int)GameObjects.ExitButton).GetComponent<Button>();

        loginButton.gameObject.BindEvent((PointerEventData) =>
        {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            walletLogin.OnLogin();
            PhotonNetwork.LocalPlayer.NickName = playerName.text;
        });
        exitButton.gameObject.BindEvent((PointerEventData) =>
        {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            Application.Quit();
        });
    }


}
