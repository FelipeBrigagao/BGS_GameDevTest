using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public int price = 0;
    public ItemTypes itemType;
}

public enum ItemTypes
{
    CLOTHING,
    WEAPON
}
