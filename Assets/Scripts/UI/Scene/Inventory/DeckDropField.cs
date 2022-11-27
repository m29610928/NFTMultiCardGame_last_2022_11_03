using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DeckDropField : UI_Base
{
    static public DeckDropField instance;

    [SerializeField]
    TMP_Text NftCardTMP;
    [SerializeField]
    TMP_Text NormalCardTMP;

    TMP_Text[] tempTMP;

    void Start()
    {
        Init();
    }

    void Update()
    {
        BindEvent(gameObject, (PointerEventData data) =>
        {
            PushCard();
        }
        , Define.UIEvent.Drop);
    }
      
    public override void Init()
    {
        instance = this;

        tempTMP = gameObject.GetComponentsInChildren<TMP_Text>();
        NormalCardTMP = tempTMP[0];
        NftCardTMP = tempTMP[1];

        GetBufferList();
    }

    public void PushCard()
    {
        if (DragSlot.instance != null)
        {
            Card _card = DragSlot.instance.GetDragSlot().GetCard();

            if (_card != null)
            {
                if (Managers.Data.PushCardToBuffer(_card))
                {
                    RenewCount();
                    Refresh.instance.MakeCardText(_card);
                    
                }
            }
        }
    }

    public void GetBufferList()
    {
        if (Managers.Data.invenCnt > 0)
        {
            RenewCount();
            foreach (Card _card in Managers.Data.GetInvenBuffer())
            {
                Refresh.instance.MakeCardText(_card);
            }
        }

    }

    public void RenewCount()
    {
        NormalCardTMP.text = "NORMAL : " + Managers.Data.normalCnt;
        NftCardTMP.text = "NFT : " + Managers.Data.nftCnt;
    }
}
