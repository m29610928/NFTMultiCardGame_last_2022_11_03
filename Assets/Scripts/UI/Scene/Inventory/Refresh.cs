using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : UI_Base
{
    static public Refresh instance;

    enum GameObjects
    {
        GridSetting,
    }

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

        Bind<GameObject>(typeof(GameObjects));
        GameObject gridSetting = Get<GameObject>((int)GameObjects.GridSetting);
    }

    public void MakeCardText(Card _card)
    {
        if (_card.type == "NFT")
        {
            TextSlotNft _text = Managers.UI.MakeSubItem<TextSlotNft>(this.transform.GetComponentInChildren<Refresh>().transform);
            _text.Init();
            _text.card = _card;
            _text.cardName.text = _card.name;
        }
        else
        {
            TextSlotNormal _text = Managers.UI.MakeSubItem<TextSlotNormal>(this.transform.GetComponentInChildren<Refresh>().transform);
            _text.Init();
            _text.card = _card;
            _text.cardName.text = _card.name;
        }
    }

    public bool DeleteCardText<T>(TextSlotNormal _textSlotNormal) 
    {
        if(_textSlotNormal != null)
        {
            Managers.Resource.DestroyImmediate(_textSlotNormal.gameObject);
            DeckDropField.instance.RenewCount();
            return true;
        }
        return false;
    }

    public bool DeleteCardText<T>(TextSlotNft _textSlotNft)
    {
        if(_textSlotNft != null)
        {
            Managers.Resource.DestroyImmediate(_textSlotNft.gameObject);
            DeckDropField.instance.RenewCount();
            return true;
        }
        return false;
    }
}
