using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Create/Data/Player")]
[System.Serializable]

public class PlayerData : ScriptableObject
{
    public Transform playerData;
}
