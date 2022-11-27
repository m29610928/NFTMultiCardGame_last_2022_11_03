using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSetting_Normal : UI_Base
{
    enum GameObjects
    {
        GridSettingNormal,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {  
        Bind<GameObject>(typeof(GameObjects));
        GameObject gridSetting = Get<GameObject>((int)GameObjects.GridSettingNormal);

        foreach ( Card _card in Managers.Data.CardDict.Values)
        {
            // ���� ����
            Slot slot = Managers.UI.MakeSubItem<Slot>(parent: gridSetting.transform);
            slot.Init();
            //���Կ� ī�� �߰�
            slot.SetCard(_card);
        }
    }
}
