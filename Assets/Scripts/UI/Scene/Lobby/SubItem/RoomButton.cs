using UnityEngine;
using UnityEngine.UI;

public class RoomButton : UI_Base
{
    enum GameObjects
    {
        RoomName,
        RoomNumber,
    }

    public Text roomName;
    public Text roomNumber;

    public Button button;
    public int btnNumber = -1;

    RoomPanel roomPanel;

    void Start()
    {
        //Init();
    }

    void Update()
    {

    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        button = GetComponent<Button>();
        roomPanel = GetComponentInParent<RoomPanel>();
        
        roomName = Get<GameObject>((int)GameObjects.RoomName).GetComponent<Text>();
        roomNumber = Get<GameObject>((int)GameObjects.RoomNumber).GetComponent<Text>();

        if(button.interactable)
            button.gameObject.BindEvent((PointerEventData) =>
            {
                Managers.Sound.Play("Button", Define.Sound.Effect);
                roomPanel.MyListClick(btnNumber);
            });

        gameObject.transform.localScale = Vector3.one * 1f;
    }

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void SetRoomNumber(string _roomNumber)
    {
        roomNumber.text = _roomNumber;
    }

}
