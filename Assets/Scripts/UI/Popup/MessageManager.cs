using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager Inst { get; private set; }
    void Awake() => Inst = this;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetMessage(string _text)
    {
        StartCoroutine(mesg(_text));
    }

    IEnumerator mesg(string _text)
    {
        GameObject go = Managers.Resource.Instantiate($"UI/Popup/SmallBoard");
        go.transform.SetParent(gameObject.transform);
        go.transform.localPosition = gameObject.transform.localPosition;
        go.transform.localScale = gameObject.transform.localScale;
        TMP_Text temp = go.GetComponentInChildren<TMP_Text>();
        temp.text = _text;

        yield return new WaitForSeconds(1.75f);
        Managers.Resource.DestroyImmediate(go);
    }
    

}
