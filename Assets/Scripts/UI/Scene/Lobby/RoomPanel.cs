using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomPanel : UI_Base
{
    enum GameObjects
    {
        Contents,
    }
    public GameObject contents;
    public List<RoomButton> roomBtnList = new List<RoomButton>();

 
    void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        roomBtnList.Clear();
        NetworkManager.OnUpdateRoomList -= MyListRenewal;
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        contents = Get<GameObject>((int)GameObjects.Contents);

        MyListInit();
        NetworkManager.OnUpdateRoomList -= MyListRenewal;
        NetworkManager.OnUpdateRoomList += MyListRenewal;
    }

    
    public void MyListInit()
    {
        for (int i = 0; i < 10; i++)
        {
            RoomButton roomButton = Managers.UI.MakeSubItem<RoomButton>(contents.transform);
            roomButton.Init();
            roomButton.btnNumber = i;
            roomButton.SetRoomName("后 规");
            roomButton.SetRoomNumber("0 / 2");
            roomButton.button.interactable = false;
            roomBtnList.Add(roomButton);
        }
        MyListRenewal();
    }

    public void MyListClick(int num)
    {
        NetworkManager.Inst.JoinRoom(NetworkManager.Inst.myList[num].Name);
        MyListRenewal();
    }
    
    public void MyListRenewal()
    {
        for (int i = 0; i < roomBtnList.Count; i++)
        {
            RoomButton roomButton = roomBtnList[i];
            roomButton.button.interactable = i < NetworkManager.Inst.myList.Count ? true : false;
            roomButton.SetRoomName(i < NetworkManager.Inst.myList.Count ? NetworkManager.Inst.myList[i].Name : "后 规");
            roomButton.SetRoomNumber(i < NetworkManager.Inst.myList.Count ? NetworkManager.Inst.myList[i].PlayerCount + "/" + NetworkManager.Inst.myList[i].MaxPlayers : "0 / 2");
        } 
    }

    
}
