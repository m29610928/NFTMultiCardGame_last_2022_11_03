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
            // 슬롯 생성
            Slot slot = Managers.UI.MakeSubItem<Slot>(parent: gridSetting.transform);
            slot.Init();
            //슬롯에 카드 추가
            slot.SetCard(_card);
        }
    }
}
