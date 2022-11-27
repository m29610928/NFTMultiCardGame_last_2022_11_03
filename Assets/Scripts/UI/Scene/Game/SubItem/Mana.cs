using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : UI_Base
{


    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public override void Init()
    {
        gameObject.transform.localScale = Vector3.one * 42f;
        gameObject.transform.localPosition = Vector3.zero;
    }
}
