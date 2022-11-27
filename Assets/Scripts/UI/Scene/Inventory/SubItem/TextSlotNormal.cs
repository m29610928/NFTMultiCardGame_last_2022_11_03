using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextSlotNormal : UI_Base
{
    [SerializeField]
    public Image image;
    [SerializeField]
    public Card card;
    [SerializeField]
    public TextMeshProUGUI cardName;


    void Start()
    {
        Init();
    }

    void Update()
    {
        // BeginDrag
        BindEvent(gameObject, (PointerEventData data) =>
        {
            DragTextSlotNormal DragSlot = Managers.UI.MakeSubItem<DragTextSlotNormal>(parent: this.transform);
            DragSlot.Init();
            DragTextSlotNormal.instance.SetDragSlot(this);
            DragTextSlotNormal.instance.rt.anchoredPosition += data.delta / DragTextSlotNormal.instance.canvas.scaleFactor;
        }
        , Define.UIEvent.BeginDrag);

        // OnDrag
        BindEvent(gameObject, (PointerEventData data) =>
        {
           DragTextSlotNormal.instance.rt.anchoredPosition += data.delta / DragTextSlotNormal.instance.canvas.scaleFactor;
        }
        , Define.UIEvent.Drag);

        // EndDrag
        BindEvent(gameObject, (PointerEventData data) =>
        {
            DragTextSlotNormal.instance.ClearSlot();
        }
        , Define.UIEvent.EndDrag);

        // Drop
        BindEvent(gameObject, (PointerEventData data) =>
        {
            DeckDropField.instance.PushCard();
        }
        , Define.UIEvent.Drop);

    }

    public override void Init()
    {
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.localPosition = Vector3.zero;

        cardName = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        image = gameObject.GetComponent<Image>();
        
    }

    // 아이템 이미지의 투명도 조절 
    private void SetColor(float _alpha)
    {
        Color color = image.color;
        color.a = _alpha;
        image.color = color;
    }
}
