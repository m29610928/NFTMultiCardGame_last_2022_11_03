using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLobbyPanel : UI_Base
{
    enum GameObjects
    {
        PlayButton,
        InventoryButton,
        ExitButton1,

    }
    
    public Button playButton;
    public Button inventoryButton;
    public Button exitButton;

    UI_Lobby ui_lobby;

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public override void Init()
    {
        ui_lobby = GetComponentInParent<UI_Lobby>();

        Bind<GameObject>(typeof(GameObjects));

        playButton = Get<GameObject>((int)GameObjects.PlayButton).GetComponent<Button>();
        inventoryButton = Get<GameObject>((int)GameObjects.InventoryButton).GetComponent<Button>();
        exitButton = Get<GameObject>((int)GameObjects.ExitButton1).GetComponent<Button>();

        playButton.gameObject.BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            ui_lobby.SetGameLobby();
        });
        inventoryButton.gameObject.BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            Managers.Scene.LoadScene(Define.Scene.Inventory);
        });
        exitButton.gameObject.BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            NetworkManager.Inst.Disconnect();
        });
    }
}
