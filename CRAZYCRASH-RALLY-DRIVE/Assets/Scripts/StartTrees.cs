using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrees : MonoBehaviour
{
    private GameObject[] startTrees;

    private GameObject Player;
    private CarCollider carCollider;

    int i = 0;
    int ii = 0;

    // Start is called before the first frame update
    void Start()
    {
        startTrees = GameObject.FindGameObjectsWithTag("StartTrees");

        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false)
        {
            while (ii != startTrees.Length)
            {
                startTrees[ii].SetActive(true);

                ii++;
            }
            ii = 0;
            //gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            while (i != startTrees.Length)
            {
                startTrees[i].SetActive(false);

                i++;
            }
            i = 0;
            gameObject.SetActive(false);
        }
    }
}
