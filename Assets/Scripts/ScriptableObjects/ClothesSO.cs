using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clothes", menuName = "Inventory/Item/Clothes")]
public class ClothesSO : ItemSO
{
    public ClothesParts ClothesPart;
    public ClipsInfo[] ClipsInfo;
    public bool IsBase;
}

public enum ClothesParts
{
    Body,
    Head,
    Torso,
    Legs
}
