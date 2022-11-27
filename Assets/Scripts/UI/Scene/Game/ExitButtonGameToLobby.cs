using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonGameToLobby : UI_Base
{
    Image image;
    public Button button;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        image = gameObject.GetComponent<Image>();
        button = gameObject.GetComponent<Button>();
        SetUp(true);
    }

    void Update()
    {
        if (_GameManager.Inst.isGaming)
        {
            if (!_GameManager.Inst.myTurn || _GameManager.Inst.isLoading)
                SetUp(false);
            else
                SetUp(true);
        }
    }

    public void SetUp(bool flag)
    {
        if (flag)
        {
            image.color = new Color32(180, 90, 0, 255);
            button.interactable = true;

        }
        else
        {
            image.color = new Color32(55, 55, 55, 100);
            button.interactable = false;
        }
    }
}
