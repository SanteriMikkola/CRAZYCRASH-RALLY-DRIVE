using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int money;

    public bool dataFileCreated;

    public GameData(CarCollider carCollider)
    {
        money = carCollider.money;
        dataFileCreated = carCollider.dataFileCreated;
    }
}