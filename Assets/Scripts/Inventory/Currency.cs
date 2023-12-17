using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Currency : MonoBehaviour
{
    private int _currentMoney;

    public int CurrentMoney { get => _currentMoney;}

    public UnityEvent<int> OnCurrencyChange;

    public void SetInicialMoney(int initialMoney)
    {
        _currentMoney = initialMoney;
        OnCurrencyChange?.Invoke(_currentMoney);
    }


    public bool RemoveMoney(int money)
    {
        if((_currentMoney - money) < 0)
        {
            return false;
        }

        _currentMoney -= money;
        OnCurrencyChange?.Invoke(_currentMoney);
        return true;
    }

    public void AddMoney(int money)
    {
        _currentMoney += money;
        OnCurrencyChange?.Invoke(_currentMoney);
    }
}
