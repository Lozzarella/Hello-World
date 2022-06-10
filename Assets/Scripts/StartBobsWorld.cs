using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBobsWorld : MonoBehaviour
{
    public GameObject bobPrefab;
    public PlayerData bobsPersonal;

    private void Awake()
    {
       GameObject clone = Instantiate(bobPrefab);
        clone.transform.position = bobsPersonal.playerData.position;
        clone.transform.rotation = bobsPersonal.playerData.rotation;
    }
}
