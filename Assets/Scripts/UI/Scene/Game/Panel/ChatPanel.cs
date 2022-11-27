using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatPanel : UI_Base
{
    enum GameObjects
    {
        ListText,
        RoomInfoText,
        ChatScrollView,
        GridSetting,
        ChatInput,
        SendBtn,
    }

    public TMP_Text listText;
    public TMP_Text roomInfoText;
    public ChatGridSetting gridSetting;
    public InputField chatInput;
    public Button sendBtn;

    public PhotonView PV;

    public List<ChatText> chatTextList;

    void Start()
    {
        Init();
    }

    void OnDestroy()
    {
        NetworkManager.OnUpdateRoom -= RoomRenewal;
        chatTextList.Clear();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        listText = Get<GameObject>((int)GameObjects.ListText).GetComponent<TMP_Text>();
        roomInfoText = Get<GameObject>((int)GameObjects.RoomInfoText).GetComponent<TMP_Text>();

        gridSetting = Get<GameObject>((int)GameObjects.GridSetting).GetComponent<ChatGridSetting>();

        chatInput = Get<GameObject>((int)GameObjects.ChatInput).GetComponent<InputField>();
        sendBtn = Get<GameObject>((int)GameObjects.SendBtn).GetComponent<Button>();
        

        sendBtn.gameObject.BindEvent((PointerEventData) => {
            Send();
        });

        SetUp();
    }

    void SetUp()
    {
        PV = gameObject.GetOrAddComponent<PhotonView>();
        chatTextList = new List<ChatText>();
        chatInput.text = "";
        RoomRenewal(PhotonNetwork.LocalPlayer.NickName, true);
        

        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        NetworkManager.OnUpdateRoom -= RoomRenewal;
        NetworkManager.OnUpdateRoom += RoomRenewal;
    }

    #region 방
    public void RoomRenewal(string playerName, bool isComing)
    {
        listText.text = "Players : [";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            listText.text += PhotonNetwork.PlayerList[i].NickName + ((i + 1 == PhotonNetwork.PlayerList.Length) ? "" : ", ");
        listText.text += "]";
        roomInfoText.text = PhotonNetwork.CurrentRoom.Name + " : " + PhotonNetwork.CurrentRoom.PlayerCount + " / " + PhotonNetwork.CurrentRoom.MaxPlayers;

        string str = isComing ? "참가" : "퇴장";
        ChatRPC(playerName + "님이 " + str + "하셨습니다", 0);

    }
    #endregion

    #region 채팅
    void OnKeyboard() { if (Input.GetKeyDown(KeyCode.Return)) Send(); }

    public void Send()
    {
        PV.RPC("ChatRPC", RpcTarget.All, PhotonNetwork.NickName + " : " + chatInput.text, 2);
        chatInput.text = "";
        chatInput.ActivateInputField();
    }

    [PunRPC] // RPC는 플레이어가 속해있는 방 모든 인원에게 전달
    void ChatRPC(string msg, int num)
    {
            string temp;
            while (true)
            {
                if (msg.Length > 18)
                {
                    temp = msg.Substring(0, 18);
                    msg = msg.Substring(18);

                    ChatText chatText = Managers.UI.MakeSubItem<ChatText>(gridSetting.transform);
                    chatText.Init();
                    if (num == 0)
                        chatText.SetText("<color=yellow>" + temp + "</color>");
                    else if (num == 1)
                        chatText.SetText("<color=blue>" + temp + "</color>");
                    else
                        chatText.SetText(temp);
                    chatTextList.Add(chatText);
                }
                else
                {
                    ChatText chatText = Managers.UI.MakeSubItem<ChatText>(gridSetting.transform);
                    chatText.Init();
                    if (num == 0)
                        chatText.SetText("<color=yellow>" + msg + "</color>");
                    else if (num == 1)
                        chatText.SetText("<color=blue>" + msg + "</color>");
                    else
                        chatText.SetText(msg);
                    chatTextList.Add(chatText);
                    break;
                }
            }
    }
    #endregion

}
