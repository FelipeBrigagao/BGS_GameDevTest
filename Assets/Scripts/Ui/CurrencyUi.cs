using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyUi : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _moneyTXT;

    public void UpdateMoneyTXT(int currentMoney)
    {
        _moneyTXT.text = $"${currentMoney.ToString()}";
    }
}
