using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndTurnBtn : UI_Base
{
    enum GameObjects
    {
        Text
    }
    public TMP_Text btnText;
    public Button button;

    void Start()
    {
        Init();
    }


    void OnDestroy()
    {
        _GameManager.OnTurnStarted -= Setup;
    }

    public override void Init()
    {
        button = GetComponent<Button>();
        _GameManager.OnTurnStarted += Setup;

        Bind<GameObject>(typeof(GameObjects));
        btnText = Get<GameObject>((int)GameObjects.Text).GetComponent<TMP_Text>();
        Setup(false);
    }


    public void Setup(bool isActive)
    {
        GetComponent<Button>().interactable = isActive;
        btnText.color = isActive ? new Color32(255, 195, 90, 255) : new Color32(55, 55, 55, 100);
    }


}