using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrees : MonoBehaviour
{
    private GameObject[] startTrees;

    private BoxCollider boxCollider;

    private GameObject Player;
    private CarCollider carCollider;

    private bool reseted = false;

    int i = 0;
    int ii = 0;

    // Start is called before the first frame update
    void Start()
    {
        startTrees = GameObject.FindGameObjectsWithTag("StartTrees");

        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false && reseted == false)
        {
            while (ii != startTrees.Length)
            {
                startTrees[ii].SetActive(true);

                var trunk = startTrees[ii].gameObject.transform.GetChild(0);

                trunk.gameObject.SetActive(true);

                ii++;
            }
            ii = 0;
            //gameObject.SetActive(false);
            boxCollider.enabled = true;
            reseted = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            while (i != startTrees.Length)
            {
                startTrees[i].SetActive(false);

                var trunk = startTrees[i].gameObject.transform.GetChild(0);

                trunk.gameObject.SetActive(false);

                i++;
            }
            i = 0;
            //gameObject.SetActive(false);
            boxCollider.enabled = false;
            reseted = false;
        }
    }
}
