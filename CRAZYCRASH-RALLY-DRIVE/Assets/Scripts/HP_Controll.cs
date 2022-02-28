using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Controll : MonoBehaviour
{
    public GameObject[] HealthPoints;
    private GameObject Player;
    private PlayerMovement playerMove;

    private int decreaseValue;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerMove = Player.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.maxOsumat == 10)
        {
            decreaseValue = 1;
        }
        else if (playerMove.maxOsumat == 5)
        {
            decreaseValue = 2;
        }
        if (playerMove.playerCollideWithOsb == true)
        {
            DecreaseHP();
        }
    }

    private void DecreaseHP()
    {
        switch (decreaseValue)
        {
            case 1:
                {
                    for (int i = 10; i > 0; i--)
                    {

                    }
                }
                break;
            case 2:
                {

                }
                break;
        }
    }
}
