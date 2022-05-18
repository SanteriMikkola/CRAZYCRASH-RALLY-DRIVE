using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarBuySystem : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;

    public GameObject Garage;
    private GarageControll garageControll;

    public GameObject garageMenuMoneyT;
    private TextMeshProUGUI garageMenuMoneyT_Text;


    public GameObject[] BuyButtons;

    public Text[] BB_texts;

    public GameObject[] PlayerCars;

    public GameObject[] ColorButtons;

    private Button[] CB_buttons;

    public GameObject[] LockedCars;

    private int car2_prize = 200;
    private int car3_prize = 300;
    private int car4_prize = 400;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
        garageControll = Garage.GetComponent<GarageControll>();
        garageMenuMoneyT_Text = garageMenuMoneyT.GetComponent<TextMeshProUGUI>();
        CB_buttons = new Button[ColorButtons.Length];

        for (int i = 0; i < ColorButtons.Length; i++)
        {
            CB_buttons[i] = ColorButtons[i].GetComponent<Button>();
        }

        BB_texts[0].text = car2_prize.ToString();
        BB_texts[1].text = car3_prize.ToString();
        BB_texts[2].text = car4_prize.ToString();
    }

    void Update()
    {
        garageMenuMoneyT_Text.text = carCollider.money.ToString();
    }

    public void CarButton2()
    {
        carCollider.LoadData();
        if (carCollider.c2_unlocked == false)
        {
            BuyButtons[0].SetActive(true);
            BuyButtons[1].SetActive(false);
            BuyButtons[2].SetActive(false);

            PlayerCars[0].SetActive(true);
            PlayerCars[1].SetActive(false);
            PlayerCars[2].SetActive(false);
            PlayerCars[3].SetActive(false);

            CB_buttons[1].interactable = false;

            LockedCars[0].SetActive(true);
            LockedCars[1].SetActive(false);
            LockedCars[2].SetActive(false);
        }
        else
        {
            PlayerCars[1].SetActive(true);
            PlayerCars[0].SetActive(false);
            PlayerCars[2].SetActive(false);
            PlayerCars[3].SetActive(false);

            CB_buttons[1].interactable = true;

            LockedCars[0].SetActive(false);
            LockedCars[1].SetActive(false);
            LockedCars[2].SetActive(false);
        }
    }
    public void CarButton3()
    {
        carCollider.LoadData();
        if (carCollider.c3_unlocked == false)
        {
            BuyButtons[1].SetActive(true);
            BuyButtons[0].SetActive(false);
            BuyButtons[2].SetActive(false);

            PlayerCars[0].SetActive(true);
            PlayerCars[1].SetActive(false);
            PlayerCars[2].SetActive(false);
            PlayerCars[3].SetActive(false);

            CB_buttons[2].interactable = false;

            LockedCars[1].SetActive(true);
            LockedCars[0].SetActive(false);
            LockedCars[2].SetActive(false);
        }
        else
        {
            PlayerCars[2].SetActive(true);
            PlayerCars[0].SetActive(false);
            PlayerCars[1].SetActive(false);
            PlayerCars[3].SetActive(false);

            CB_buttons[2].interactable = true;

            LockedCars[0].SetActive(false);
            LockedCars[1].SetActive(false);
            LockedCars[2].SetActive(false);
        }
    }
    public void CarButton4()
    {
        carCollider.LoadData();
        if (carCollider.c4_unlocked == false)
        {
            BuyButtons[2].SetActive(true);
            BuyButtons[0].SetActive(false);
            BuyButtons[1].SetActive(false);

            PlayerCars[0].SetActive(true);
            PlayerCars[1].SetActive(false);
            PlayerCars[2].SetActive(false);
            PlayerCars[3].SetActive(false);

            CB_buttons[3].interactable = false;

            LockedCars[2].SetActive(true);
            LockedCars[0].SetActive(false);
            LockedCars[1].SetActive(false);
        }
        else
        {
            PlayerCars[3].SetActive(true);
            PlayerCars[0].SetActive(false);
            PlayerCars[1].SetActive(false);
            PlayerCars[2].SetActive(false);

            CB_buttons[3].interactable = true;

            LockedCars[0].SetActive(false);
            LockedCars[1].SetActive(false);
            LockedCars[2].SetActive(false);
        }
    }

    
    public void BuyCar2()
    {
        if (carCollider.money >= car2_prize)
        {
            carCollider.money -= car2_prize;
            carCollider.c2_unlocked = true;

            BuyButtons[0].SetActive(false);

            PlayerCars[1].SetActive(true);
            PlayerCars[0].SetActive(false);
            PlayerCars[2].SetActive(false);
            PlayerCars[3].SetActive(false);

            CB_buttons[1].interactable = true;

            LockedCars[0].SetActive(false);

            garageControll.loadData = true;

            carCollider.SaveData();
            carCollider.LoadData();
        }
    }
    public void BuyCar3()
    {
        if (carCollider.money >= car3_prize)
        {
            carCollider.money -= car3_prize;
            carCollider.c3_unlocked = true;

            BuyButtons[1].SetActive(false);

            PlayerCars[2].SetActive(true);
            PlayerCars[0].SetActive(false);
            PlayerCars[1].SetActive(false);
            PlayerCars[3].SetActive(false);

            CB_buttons[2].interactable = true;

            LockedCars[1].SetActive(false);

            garageControll.loadData = true;

            carCollider.SaveData();
            carCollider.LoadData();
        }
    }
    public void BuyCar4()
    {
        if (carCollider.money >= car4_prize)
        {
            carCollider.money -= car4_prize;
            carCollider.c4_unlocked = true;

            BuyButtons[2].SetActive(false);

            PlayerCars[3].SetActive(true);
            PlayerCars[0].SetActive(false);
            PlayerCars[1].SetActive(false);
            PlayerCars[2].SetActive(false);

            CB_buttons[3].interactable = true;

            LockedCars[2].SetActive(false);

            garageControll.loadData = true;

            carCollider.SaveData();
            carCollider.LoadData();
        }
    }
}
