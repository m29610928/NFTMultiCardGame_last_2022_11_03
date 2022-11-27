using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : UI_Base
{
    enum GameObjects
    {
        NotificationPanel,
        ResultPanel,
        TitlePanel,
        ChatPanel,
    }

    public NotificationPanel notificationPanel;
    public ResultPanel resultPanel;
    public TitlePanel titlePanel;
    public ChatPanel chatPanel;

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        notificationPanel = Get<GameObject>((int)GameObjects.NotificationPanel).GetComponent<NotificationPanel>();
        resultPanel = Get<GameObject>((int)GameObjects.ResultPanel).GetComponent<ResultPanel>();
        titlePanel = Get<GameObject>((int)GameObjects.TitlePanel).GetComponent<TitlePanel>();
        chatPanel = Get<GameObject>((int)GameObjects.ChatPanel).GetComponent<ChatPanel>();
    }

    void UISetup()
    {
        notificationPanel.ScaleZero();
        resultPanel.ScaleZero();
        titlePanel.gameObject.SetActive(true);
        chatPanel.gameObject.SetActive(true);
    }

    public void Notification(string message)
    {
        notificationPanel.Show(message);
    }
}
