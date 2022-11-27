using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NftButton : UI_Base
{
    enum GameObjects
    {
        NftButton,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        ChangeInven changeInven = gameObject.GetComponentInParent<ChangeInven>();

        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.NftButton).BindEvent((PointerEventData) =>
        {
            Managers.Sound.Play("Button", Define.Sound.Effect);
            changeInven.OpenInvenNft();
        }
        );

    }

    void Update()
    {
        
    }
}
