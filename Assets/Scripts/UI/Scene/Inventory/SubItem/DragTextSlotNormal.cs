using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragTextSlotNormal : UI_Base
{
    static public DragTextSlotNormal instance;

    public RectTransform rt;
    public Canvas canvas;

    [SerializeField]
    TextSlotNormal dragSlot;

    [SerializeField]
    public SpriteRenderer image;
    [SerializeField]
    public Card card;
    [SerializeField]
    public TMP_Text cardName;

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public override void Init()
    {

        instance = this;

        Vector3 temp = new Vector3(44f, 24.5f, 10f);
        gameObject.transform.localScale = temp;
        gameObject.transform.localPosition = Vector3.zero;

        rt = (RectTransform)gameObject.transform;
        canvas = gameObject.GetComponentInParent<Canvas>();

        image = gameObject.GetComponent<SpriteRenderer>();
        cardName = gameObject.GetComponentInChildren<TMP_Text>();
        
    }

    public void SetDragSlot(TextSlotNormal _slot)
    {
        dragSlot = _slot;
        card = _slot.card;
        image.sprite = _slot.image.sprite;
        cardName.text = _slot.cardName.text;  
        SetColor(0.55f);
    }


    public void SetColor(float _alpha)
    {
        Color color = image.color;
        color.a = _alpha;
        image.color = color;
    }

    public void ClearSlot()
    {
        dragSlot = null;
        image = null;
        cardName = null;
        Destroy(gameObject);
    }

    public TextSlotNormal GetDragSlot()
    {
        return dragSlot;
    }

    public Card GetCard()
    {
        return card;
    }

    public SpriteRenderer GetCardImage()
    {
        return image;
    }

}
