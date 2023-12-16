using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CurrencyUi _currencyUi;
    private int _currentMoney;

    public int CurrentMoney { get => _currentMoney;}


    public void SetInicialMoney(int initialMoney)
    {
        _currentMoney = initialMoney;
        _currencyUi?.UpdateMoneyTXT(_currentMoney);
    }


    public bool RemoveMoney(int money)
    {
        if((_currentMoney - money) < 0)
        {
            return false;
        }

        _currentMoney -= money;
        _currencyUi?.UpdateMoneyTXT(_currentMoney);
        return true;
    }

    public void AddMoney(int money)
    {
        _currentMoney += money;
        _currencyUi?.UpdateMoneyTXT(_currentMoney);
    }
}
