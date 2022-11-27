using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lobby : UI_Base
{
    enum GameObjects
    {
        InfoPanel,
        MainLobbyPanel,
        GameLobbyPanel,
        MessageManager,
    }

    public GameLobbyPanel gameLobby;
    public MainLobbyPanel mainLobby;
    public InfoPanel infoPanel;

    void Start()
    {
        Init();
    }


    public override void Init()
    {

        Bind<GameObject>(typeof(GameObjects));

        mainLobby = Get<GameObject>((int)GameObjects.MainLobbyPanel).GetComponent<MainLobbyPanel>();
        gameLobby = Get<GameObject>((int)GameObjects.GameLobbyPanel).GetComponent<GameLobbyPanel>();
        infoPanel = Get<GameObject>((int)GameObjects.InfoPanel).GetComponent<InfoPanel>();

        SetUp();
    }
    void SetUp()
    {
        gameLobby.transform.localScale = Vector3.one * 0f;

        if (Managers.Scene.LastScene.SceneType == Define.Scene.Game || Managers.Scene.LastScene.SceneType == Define.Scene.MultiGame)
        {
            SetGameLobby();
            return;
        }
        SetMainLobby(); 
    }

    public void SetMainLobby()
    {
        mainLobby.gameObject.SetActive(true);
        gameLobby.gameObject.SetActive(false);
    }

    public void SetGameLobby()
    {
        gameLobby.transform.localScale = Vector3.one;
        mainLobby.gameObject.SetActive(false);
        gameLobby.gameObject.SetActive(true);
    }

}
