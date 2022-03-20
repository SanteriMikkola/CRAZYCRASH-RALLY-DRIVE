using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_Controll : MonoBehaviour
{
    private GameObject FuelMeterArrow;
    private GameObject Player;
    private GameObject Kamera;
    private PlayerMovement playerMove;
    private CarCollider carCollider;
    private CarController carController;

    private bool deCreased = false;
    private bool inCreased = false;
    private float decreaseValue = 0.06f;
    private float decreaseFuel = 0.0096f;
    private float increaseValue = 4f;
    private float increaseFuel = 100f;

    private float rotationZ = -80.5f;

    public Vector3 fuelDecreaseDelay;

    private bool Reseted = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        FuelMeterArrow = GameObject.Find("Arrow");
        //playerMove = Player.GetComponent<PlayerMovement>();
        carCollider = Player.GetComponent<CarCollider>();
        carController = Player.GetComponent<CarController>();
        Kamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //HitValueCheck();

        if (carCollider.isThatLevel2 && Reseted == false)
        {
            fuelDecreaseDelay.z = 0;
            Reseted = true;
        }

        if (carCollider.fuel <= 0 && rotationZ >= 83f)
        {
            carCollider.isPlayerDead = true;
            Player.SetActive(false);
            Kamera.SetActive(false);
            carCollider.playerCollide = false;
        }

        if (carCollider.jerryCanPicked == true)
        {
            StartCoroutine(JerryCanReverseFullHealth());
        }

        if (carController.IsTutorialEnded == true && carCollider.playerCollide == false && carCollider.isPlayerDead == false && carCollider.jerryCanPicked == false)
        {
            if (rotationZ < 83f)
            {
                StartCoroutine(DecreaseFuel());
            }
            else
            {
                carCollider.fuel = 0;
            }
        }

        /*if (carCollider.jerryCanPicked == false)
        {
            healed = false;
        }*/
        if (carCollider.isPlayerDead == true)
        {
            rotationZ = 82f;
            FuelMeterArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }

    IEnumerator DecreaseFuel()
    {
        carCollider.fuel -= decreaseFuel;

        while (!deCreased)
        {
            rotationZ = (rotationZ + decreaseValue);
            //Debug.Log(rotationZ);
            fuelDecreaseDelay.z = Player.transform.position.z + 0.00002f;
            deCreased = true;
        }

        yield return new WaitUntil(() => Player.transform.position.z >= fuelDecreaseDelay.z);
        //Debug.Log("Hep!");
        FuelMeterArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        deCreased = false;
    }

    /*private void HitValueCheck()
    {
        if (carCollider.maxOsumat == 10)    //10 osumaa
        {
            decreaseValue = 1f;
        }
        else if (carCollider.maxOsumat == 5)    //5 osumaa
        {
            decreaseValue = 2f;
        }
        else if (carCollider.maxOsumat == 4)    //4 osumaa
        {
            decreaseValue = 2.5f;
        }
        else if (carCollider.maxOsumat == 3)    //3 osumaa
        {
            decreaseValue = 3.33f;
        }
        else if (carCollider.maxOsumat == 2)    //2 osumaa
        {
            decreaseValue = 5f;
        }
    }*/

    IEnumerator JerryCanReverseFullHealth()
    {
        //carCollider.isThatFullHealthReverse = true;
        /*if (carCollider.jerryCanPicked == true)
        {
            rotationZ = -80.5f;
            FuelMeterArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            carCollider.jerryCanPicked = false;
        }*/
        while (rotationZ > -80.5f)
        {


            while (!inCreased)
            {
                rotationZ = (rotationZ - increaseValue);
                //Debug.Log(rotationZ);
                fuelDecreaseDelay.z = Player.transform.position.z + 0.0001f;
                inCreased = true;

            }

            yield return new WaitUntil(() => Player.transform.position.z >= fuelDecreaseDelay.z);
            //Debug.Log("Hep!");
            carCollider.fuel = increaseFuel;
            FuelMeterArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            inCreased = false;
        }
        carCollider.jerryCanPicked = false;
    }

    /*private void ToolBoxReverse2Health()
    {
        carCollider.isThatFullHealthReverse = false;
        if (carCollider.toolBoxPicked == true)
        {
            switch (decreaseValue)
            {
                case 1f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value >= 0.2f)
                            {
                                HealthPointsScrollBar.value -= 0.2f;
                            }
                            else if (HealthPointsScrollBar.value == 0.1f)
                            {
                                HealthPointsScrollBar.value -= 0.1f;
                            }
                            healed = true;
                        }
                    }
                    break;
                case 2f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value >= 0.6f)
                            {
                                HealthPointsScrollBar.value -= 0.4f;
                            }
                            else if (HealthPointsScrollBar.value <= 0.4f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
                case 2.5f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value >= 0.5f)
                            {
                                HealthPointsScrollBar.value -= 0.5f;
                            }
                            else if (HealthPointsScrollBar.value < 0.5f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
                case 3.33f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value <= 0.66f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
                case 5f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value <= 0.5f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
            }
            carCollider.toolBoxPicked = false;
        }
    }*/
}
