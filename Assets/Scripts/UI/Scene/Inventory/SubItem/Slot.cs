using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Slot : UI_Base
{
    [SerializeField]
    Card card;

    [SerializeField]
    Image cardImage;
    [SerializeField]
    Image cardFrame;
 
    [SerializeField]
    TMP_Text nameTMP;
    [SerializeField]
    TMP_Text attackTMP;
    [SerializeField]
    TMP_Text healthTMP;
    [SerializeField]
    TMP_Text costTMP;

    TMP_Text[] tempTMP;
    Image[] tempImage;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.localPosition = Vector3.zero;

        tempImage = gameObject.GetComponentsInChildren<Image>();
        cardImage = tempImage[0];
        cardFrame = tempImage[1];

        tempTMP = gameObject.GetComponentsInChildren<TMP_Text>();
        nameTMP = tempTMP[0];
        attackTMP = tempTMP[1];
        healthTMP = tempTMP[2];
        costTMP = tempTMP[3];

    }

    void Update()
    {
        // BeginDrag
        BindEvent(gameObject, (PointerEventData data) =>
        {
            DragSlot DragSlot = Managers.UI.MakeSubItem<DragSlot>(parent: this.transform);
            DragSlot.Init();
            DragSlot.instance.SetDragSlot(this);
            DragSlot.instance.rt.anchoredPosition += data.delta / DragSlot.instance.canvas.scaleFactor;
        }
        , Define.UIEvent.BeginDrag);

        // OnDrag
        BindEvent(gameObject, (PointerEventData data) =>
        {
            DragSlot.instance.rt.anchoredPosition += data.delta / DragSlot.instance.canvas.scaleFactor;
        }
        , Define.UIEvent.Drag);

        // EndDrag
        BindEvent(gameObject, (PointerEventData data) =>
        {
            DragSlot.instance.ClearSlot();
        }
        , Define.UIEvent.EndDrag);

        
        // 드랍
        BindEvent(gameObject, (PointerEventData data) =>
        {
            TextDropField.instance.PopCard();
        }
        , Define.UIEvent.Drop);
        
    }


    // 슬롯에 카드 추가
    public void SetCard(Card _card)
    {
        card = _card;
        cardImage.sprite = _card.sprite;
        if(_card.type == "NFT")
            cardFrame.sprite = Resources.Load("Prefabs/CardGameProject_jpg/NftCardFrame", typeof(Sprite)) as Sprite;
        else
            cardFrame.sprite = Resources.Load("Prefabs/CardGameProject_jpg/CardFrame", typeof(Sprite)) as Sprite;
        nameTMP.text = this.card.name;
        attackTMP.text = this.card.attack.ToString();
        healthTMP.text = this.card.health.ToString();
        costTMP.text = this.card.cost.ToString();

        SetColor(1); 
    }

    // 해당 슬롯 삭제
    private void ClearSlot()
    {
        card = null;
        cardImage = null;
        cardFrame = null;
        nameTMP.text = null;
        attackTMP = null;
        healthTMP.text = null;
        costTMP.text = null;
        SetColor(0);
        Destroy(gameObject);
    }

    // 아이템 이미지의 투명도 조절 
    private void SetColor(float _alpha)
    {
        Color color = cardImage.color;
        color.r = _alpha;
        color.g = _alpha;
        color.b = _alpha;
        color.a = _alpha;
        cardImage.color = color;
    }

    private void ChangeCard()
    {
        Card _tempCard = this.card;

        if(DragSlot.instance != null)
        {
            SetCard( DragSlot.instance.GetDragSlot().GetCard() );

            if (_tempCard != null)
                DragSlot.instance.GetDragSlot().SetCard(_tempCard);
            else
                DragSlot.instance.ClearSlot();
        }
    }
    
    public Card GetCard()
    {
        return card;
    }

    public Image GetCardImage()
    {
        return cardImage;
    }

    public Image GetCardFrame()
    {
        return cardFrame;
    }
}

