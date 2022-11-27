using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryToLobby_Button : UI_Base
{
    enum GameObjects
    {
        ExitButton,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ExitButton).BindEvent((PointerEventData) => {
            Managers.Sound.Play("Button", Define.Sound.Effect); 
            Managers.Scene.LoadScene(Define.Scene.Lobby); 
        });
    }

    void Update()
    {

    }
}
