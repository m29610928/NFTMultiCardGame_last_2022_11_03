using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextDropField : UI_Base
{
    static public TextDropField instance;

    Image iamge;

    void Start()
    {
        Init();
    }

    void Update()
    {
        BindEvent(gameObject, (PointerEventData data) =>
        {
            PopCard();
        }
        , Define.UIEvent.Drop);
    }

    public override void Init()
    {
        instance = this;
        iamge = GetComponent<Image>();
    }

    public void PopCard()
    {
        if (DragTextSlotNormal.instance != null )
        {
            TextSlotNormal _textSlot = DragTextSlotNormal.instance.GetDragSlot();

            if (_textSlot != null)
            {
                if (Managers.Data.PopCardFromBuffer(_textSlot.card))
                {
                    Refresh.instance.DeleteCardText<TextSlotNormal>(_textSlot);
                }
            }
        }
        if (DragTextSlotNft.instance != null)
        {
            TextSlotNft _textSlot = DragTextSlotNft.instance.GetDragSlot();

            if (_textSlot != null)
            {
                if (Managers.Data.PopCardFromBuffer(_textSlot.card))
                {
                    Refresh.instance.DeleteCardText<TextSlotNft>(_textSlot);
                }
            }
        }

    }
}
