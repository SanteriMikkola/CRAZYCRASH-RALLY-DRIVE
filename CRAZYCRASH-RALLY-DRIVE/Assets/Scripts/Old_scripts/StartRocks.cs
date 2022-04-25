using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRocks : MonoBehaviour
{
    private GameObject[] startRock;

    //private SphereCollider sphereCollider;

    private GameObject Player;
    private CarCollider carCollider;
    private StartTrees startTreesS;

    public bool ReSet = true;

    int i = 0;
    int ii = 0;

    // Start is called before the first frame update
    void Start()
    {
        startRock = GameObject.FindGameObjectsWithTag("StartRocks");

        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        startTreesS = gameObject.GetComponent<StartTrees>();

        //sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false && startTreesS.reseted == false && ReSet == true)
        {
            while (ii != startRock.Length)
            {
                startRock[ii].SetActive(true);

                /*var trunk = startTrees[ii].gameObject.transform.GetChild(0);

                trunk.gameObject.SetActive(true);*/

                ii++;
            }
            ii = 0;
            //gameObject.SetActive(false);
            //sphereCollider.enabled = true;
            ReSet = false;
        }
    }
}