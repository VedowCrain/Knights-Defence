using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon", order = 1)]

public class Weapon : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public float damage = 10f;
    public float minRange = 0.5f;
    public float maxRange = 5f;
}
