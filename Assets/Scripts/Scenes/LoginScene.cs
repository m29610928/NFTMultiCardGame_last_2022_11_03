using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;
    }

    public override void Clear()
    {
        Debug.Log("LoginSceneClear!!");
    }

}
