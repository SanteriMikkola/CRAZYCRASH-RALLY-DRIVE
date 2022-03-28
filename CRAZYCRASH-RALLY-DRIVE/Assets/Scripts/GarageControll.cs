using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageControll : MonoBehaviour
{
    public GameObject[] Cars;
    public Color[] Colors;
    public GameObject[] Hats;

    public int index = 0;

    public bool pressedRight, pressedLeft,
                pressedCarB, pressedPaintB,
                pressedHatB;


    void Start()
    {
        pressedRight = false;
        pressedLeft = false;
        pressedCarB = true;
        pressedPaintB = false;
        pressedHatB = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressedRight == true && pressedLeft == false)
        {
            index++;
            ChangeChoose();
        }
        if (pressedRight == false && pressedLeft == true)
        {
            if (index >= 1)
            {
                index--;
            }
            ChangeChoose();
        }
    }

    private void ChangeChoose()
    {
        if (pressedCarB == true && pressedPaintB == false && pressedHatB == false)
        {
            Cars[index].SetActive(true);
        }
        if (pressedCarB == false && pressedPaintB == true && pressedHatB == false)
        {

        }
        if (pressedCarB == false && pressedPaintB == false && pressedHatB == true)
        {

        }
    }

    public void PressedCarB()
    {
        pressedCarB = true;
        pressedPaintB = false;
        pressedHatB = false;
    }

    public void PressedPaintB()
    {
        pressedPaintB = true;
        pressedCarB = false;
        pressedHatB = false;
    }

    public void PressedHatB()
    {
        pressedHatB = true;
        pressedCarB = false;
        pressedPaintB = false;
    }

    public void PressedRightA()
    {
        pressedRight = true;
    }

    public void PressedLeftA()
    {
        pressedLeft = true;
    }
}
