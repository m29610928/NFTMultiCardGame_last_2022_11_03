using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInven : MonoBehaviour
{
    [SerializeField]
    InvenNormal invenNormal;
    [SerializeField]
    InvenNft invenNft;

    void Start()
    {
        invenNormal = gameObject.GetComponentInChildren<InvenNormal>();
        invenNft= gameObject.GetComponentInChildren<InvenNft>();
        invenNft.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OpenInvenNormal()
    {
        invenNormal.gameObject.SetActive(true);
        invenNft.gameObject.SetActive(false);
    }

    public void OpenInvenNft()
    {
        invenNormal.gameObject.SetActive(false);
        invenNft.gameObject.SetActive(true);
    }
}
