using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptionButton : UI_Base
{
    enum GameObjects
    {
        DescriptionButton,
        Description,
    }

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
        GameObject go = Get<GameObject>((int)GameObjects.Description).gameObject;
        go.SetActive(false);
        go.transform.localScale = Vector3.one * 0.035f;

        Get<GameObject>((int)GameObjects.DescriptionButton).BindEvent((PointerEventData) => {
           if(go.activeSelf == true)
            {
                go.SetActive(false);
            }
            else
            {
                go.SetActive(true);
            }
            Managers.Sound.Play("Button", Define.Sound.Effect);
        });

    }

}
