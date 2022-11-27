using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetting_Nft : UI_Base
{
    enum GameObjects
    {
        GridSettingNft,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        GameObject gridSetting = Get<GameObject>((int)GameObjects.GridSettingNft);

        foreach (Card _card in Managers.Data.NftCardDict.Values)
        {
            // ���� ����
            Slot slot = Managers.UI.MakeSubItem<Slot>(parent: gridSetting.transform);
            slot.Init();
            //���Կ� ī�� �߰�
            slot.SetCard(_card);
        }
    }
}
