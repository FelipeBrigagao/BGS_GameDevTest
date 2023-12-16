using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Character/Shop")]
public class ShopSO : ScriptableObject 
{
    public string ShopName = "New Shop";
    public int InitialMoney = 10;
    public int MaxSlots = 10;
    public List<ItemSO> Items;
}
