using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Character/Player")]
public class PlayerSO : ScriptableObject
{
    public int InitialMoney;
    public int MaxInventorySlots;

    public ClothesSO BaseBodyClothes;
    public ClothesSO BaseHeadClothes;
    public ClothesSO BaseTorsoClothes;
    public ClothesSO BaseLegsClothes;
}
