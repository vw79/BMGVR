using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class SO_Gun : ScriptableObject
{
    public string gunType;
    public GameObject gunPrefab;
    public int gunCount;
}
