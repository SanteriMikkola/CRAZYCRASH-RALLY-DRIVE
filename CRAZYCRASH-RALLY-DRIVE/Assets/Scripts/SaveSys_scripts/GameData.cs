using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int money;
    public bool dataFileCreated;
    public int PickedCar;

    public bool c_isThatOldCar;
    public bool c_isThatCar3;
    public bool c_isThatCar4;
    public int colorIndex;
    public int carIndex;

    public int colorIndexOfCar1;
    public int colorIndexOfCar2;
    public int colorIndexOfCar3;
    public int colorIndexOfCar4;

    public GameData(CarCollider carCollider)
    {
        money = carCollider.money;
        PickedCar = carCollider.PickedCar;
        c_isThatOldCar = carCollider.c_isThatOldCar;
        c_isThatCar3 = carCollider.c_isThatCar3;
        c_isThatCar4 = carCollider.c_isThatCar4;
        colorIndex = carCollider.colorIndex;
        colorIndexOfCar1 = carCollider.colorIndexOfCar1;
        colorIndexOfCar2 = carCollider.colorIndexOfCar2;
        colorIndexOfCar3 = carCollider.colorIndexOfCar3;
        colorIndexOfCar4 = carCollider.colorIndexOfCar4;
        carIndex = carCollider.carIndex;
    }
}