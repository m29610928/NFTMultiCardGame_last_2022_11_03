using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
    [SerializeField]
    TMP_Text otherCostText;
    [SerializeField]
    TMP_Text otherCostMaxText;
 
    TMP_Text[] temp;

    void Start()
    {
        temp = GetComponentsInChildren<TMP_Text>();
        otherCostText = temp[0];
        otherCostMaxText = temp[2];

        ManaManager.OnAddMana += AddManaSetText;
        ManaManager.OnUseMana += UseManaSetText;
        ManaManager.OnInitMana += ManaMaxSetText;
        otherCostText.text = "0";
        otherCostMaxText.text = "0";
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
        if (isMine == true)
            return;

        otherCostText.text = k.ToString();
    }
    void UseManaSetText(int k, bool isMine)
    {
        if (isMine == true)
            return;

        otherCostText.text = k.ToString();
    }

    void ManaMaxSetText(int k, bool isMine)
    {
        if (isMine == true)
            return;

        otherCostMaxText.text = k.ToString();
    }
}
