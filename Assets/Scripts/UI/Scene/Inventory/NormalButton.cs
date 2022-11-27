using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalButton : UI_Base
{
    enum GameObjects
    {
        NormalButton,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        ChangeInven changeInven = gameObject.GetComponentInParent<ChangeInven>();

        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.NormalButton).BindEvent((PointerEventData) =>
        {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            changeInven.OpenInvenNormal();
        }
        );
    }

    void Update()
    {

    }
}
