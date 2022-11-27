using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField]
    TMP_Text myCostText;
    [SerializeField]
    TMP_Text myCostMaxText;

    TMP_Text[] temp;

    void Start()
    {
        temp = GetComponentsInChildren<TMP_Text>();
        myCostText = temp[0];
        myCostMaxText = temp[2];

        ManaManager.OnAddMana += AddManaSetText;
        ManaManager.OnUseMana += UseManaSetText;
        ManaManager.OnInitMana += ManaMaxSetText;
        myCostText.text = "0";
        myCostMaxText.text = "0";
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        ManaManager.OnAddMana -= AddManaSetText;
        ManaManager.OnUseMana -= UseManaSetText;
        ManaManager.OnInitMana -= ManaMaxSetText;
    }

    void AddManaSetText(int k, bool isMine)
    {
        if (isMine == false)
            return;

        myCostText.text = k.ToString();
    }

    void UseManaSetText(int k, bool isMine)
    {
        if (isMine == false)
            return;

        myCostText.text = k.ToString();
    }
    
    void ManaMaxSetText(int k, bool isMine)
    {
        if (isMine == false)
            return;
        
        myCostMaxText.text = k.ToString();

    }
}
