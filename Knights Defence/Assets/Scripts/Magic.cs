using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Magic Type", menuName = "Inventory/Magic", order = 2)]

public class Magic : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public float damage = 10f;
}
