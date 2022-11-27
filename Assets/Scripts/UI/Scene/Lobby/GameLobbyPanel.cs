using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLobbyPanel : UI_Base
{
    enum GameObjects
    {
        RoomNameInput,
        MakeRoomButton,
        RandomMatchButton,
        SinglePlayButton,
        RoomPanel,
        ExitButton2,
    }

    public InputField roomNameInput;
    public GameObject makeRoomBtn;
    public GameObject randomMatchBtn;
    public GameObject singlePlayBtn;
    public RoomPanel roomPanel;
    public GameObject exitBtn2;

    UI_Lobby ui_lobby;

    void Start()
    {
        Init();
    }


    public override void Init()
    {

        ui_lobby = GetComponentInParent<UI_Lobby>();

        Bind<GameObject>(typeof(GameObjects));

        roomNameInput = Get<GameObject>((int)GameObjects.RoomNameInput).GetComponent<InputField>();
        makeRoomBtn = Get<GameObject>((int)GameObjects.MakeRoomButton);
        randomMatchBtn = Get<GameObject>((int)GameObjects.RandomMatchButton);
        singlePlayBtn = Get<GameObject>((int)GameObjects.SinglePlayButton);
        roomPanel = Get<GameObject>((int)GameObjects.RoomPanel).GetComponent<RoomPanel>();
        exitBtn2 = Get<GameObject>((int)GameObjects.ExitButton2);

        makeRoomBtn.BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            NetworkManager.Inst.CreateRoom(GetRoomNameInput());
            SetRoomNameInput("");
        });

        randomMatchBtn.BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            NetworkManager.Inst.JoinRandomRoom();
        });

        singlePlayBtn.BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            MessageManager.Inst.SetMessage("현재 서비스중인 기능이 아닙니다..");
            //NetworkManager.Inst.SinglePlay();
        });
        exitBtn2.BindEvent((PointerEventData) =>
        {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            ui_lobby.SetMainLobby();
        });
    }

    public string GetRoomNameInput()
    {
        return roomNameInput.text;
    }

    public void SetRoomNameInput(string roomName)
    {
        roomNameInput.text = roomName;
    }

}
