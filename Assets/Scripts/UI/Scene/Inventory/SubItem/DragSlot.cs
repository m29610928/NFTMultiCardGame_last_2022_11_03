using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DragSlot : UI_Base
{
    static public DragSlot instance;

    public RectTransform rt;
    public Canvas canvas;

    [SerializeField]
    Slot dragSlot;

    [SerializeField]
    SpriteRenderer cardImage;
    [SerializeField]
    SpriteRenderer cardFrame;

    [SerializeField]
    TMP_Text nameTMP;
    [SerializeField]
    TMP_Text attackTMP;
    [SerializeField]
    TMP_Text healthTMP;
    [SerializeField]
    TMP_Text costTMP;

    TMP_Text[] tempTMP;
    SpriteRenderer[] tempImage;


    void Start()
    {
        Init();   
    }

    // Init 함수보다 BindEvent 함수들이 우선이기 때문에 Init()을 BINDEVENT와함께 쓸때는 
    // 항상 먼저 꼭 사용해주기!!
    public override void Init()
    {
        instance = this;

        gameObject.transform.localScale = Vector3.one * 0.80f;
        gameObject.transform.localPosition = Vector3.zero;

        
        rt = (RectTransform)gameObject.transform;
        canvas = gameObject.GetComponentInParent<Canvas>();
        cardImage = gameObject.GetComponent<SpriteRenderer>();

        tempImage = gameObject.GetComponentsInChildren<SpriteRenderer>();
        cardImage = tempImage[0];
        cardFrame = tempImage[1];

        

        tempTMP = gameObject.GetComponentsInChildren<TMP_Text>();
        nameTMP = tempTMP[0];
        attackTMP = tempTMP[1];
        healthTMP = tempTMP[2];
        costTMP = tempTMP[3];
    }

    private void Update()
    {

    }

    public void SetDragSlot(Slot _slot)
    {
        dragSlot = _slot;
        Card _card = dragSlot.GetCard();
        cardImage.sprite = _card.sprite;
        cardFrame.sprite = _slot.GetCardFrame().sprite; 
        nameTMP.text = _card.name;
        attackTMP.text = _card.attack.ToString();
        healthTMP.text = _card.health.ToString();
        costTMP.text = _card.cost.ToString();   
        SetColor(0.80f);
    }


    public void SetColor(float _alpha)
    {
        Color color = cardImage.color;
        color.r = _alpha;
        color.g = _alpha;
        color.b = _alpha;
        color.a = _alpha;
        cardImage.color = color;
        cardFrame.color = color;
    }

    public void ClearSlot()
    {
        dragSlot = null;
        cardImage = null;
        cardFrame = null;
        nameTMP= null;
        attackTMP = null;
        healthTMP = null;
        costTMP = null;
        Destroy(gameObject);
    }

    public Slot GetDragSlot()
    {
        return dragSlot;
    }

    public SpriteRenderer GetCardImage()
    {
        return cardImage;
    }
}
