using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Player Data", menuName = "Create/Data/Player")]
[System.Serializable]
public class pdTransform //We just made out own Transform for saving and loading
    //gets the position, rotation, and scale of gameobject/player
{
    public Vector3 position;
    public Quaternion rotation;

    public pdTransform()
    {
        position = Vector3.zero;
        rotation = Quaternion.identity;
    }
}

[System.Serializable]

public class PlayerData
{
    public string name = "";
    public pdTransform playerData;

    public void SaveFromTransform(Transform otherTransform)
    {
        name = otherTransform.name;
        playerData.position = otherTransform.position;
        playerData.rotation = otherTransform.rotation;
    }

    public void LoadToTransform(ref Transform otherTransform)
    {
        if (otherTransform == null) return;

        otherTransform.name = name;
        otherTransform.position = playerData.position;
        otherTransform.rotation = playerData.rotation;
    }

    public PlayerData()
    {
        playerData = new pdTransform();
        name = "";
    }
}
