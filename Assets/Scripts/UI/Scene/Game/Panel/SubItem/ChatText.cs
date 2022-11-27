using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatText : UI_Base
{
    Text text;

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public override void Init()
    {
        text = GetComponent<Text>();    
        gameObject.transform.localScale = Vector3.one;
    }

    public void SetText(string str)
    {
        text.text = str;
    }
}
