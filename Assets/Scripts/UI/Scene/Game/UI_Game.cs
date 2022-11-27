using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : UI_Base
{
    enum GameObjects
    {
        Panels,
        EndTurnBtn,
        MyPlayer,
        EnemyPlayer,
        ExitButton,
    }

    public Panel panels;
    public EndTurnBtn endTurnBtn;
    public Button exitBtn;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (endTurnBtn.button.interactable == true)
        {
            
        }

    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        panels = Get<GameObject>((int)GameObjects.Panels).GetComponent<Panel>();
        endTurnBtn = Get<GameObject>((int)GameObjects.EndTurnBtn).GetComponent<EndTurnBtn>();
        exitBtn = Get<GameObject>((int)GameObjects.ExitButton).GetComponent<Button>();

        endTurnBtn.gameObject.BindEvent((PointerEventData) => {
            EndTurnBtnClicked();
        });
        exitBtn.gameObject.BindEvent((PointerEventData) => {
            ExitBtnClicked();
        });
    }

    public void EndTurnBtnClicked()
    {
        if (!endTurnBtn.button.interactable)
            return;

        Managers.Sound.Play("Button", Define.Sound.Effect);
        _GameManager.Inst.EndTurn();
        endTurnBtn.Setup(false);
    }

    public void ExitBtnClicked()
    {
        if (!exitBtn.interactable)
            return;

        exitBtn.interactable = false;
        Managers.Sound.Play("Button", Define.Sound.Effect);

        if (_GameManager.Inst.isGaming)
            _GameManager.Inst.GameOver();
        else
        {
            if (Managers.Scene.CurrentScene.SceneType == Define.Scene.MultiGame)
                NetworkManager.Inst.LeaveRoom();
            else if (Managers.Scene.CurrentScene.SceneType == Define.Scene.Game)
                Managers.Scene.LoadScene(Define.Scene.Lobby);
        }
    }
}
