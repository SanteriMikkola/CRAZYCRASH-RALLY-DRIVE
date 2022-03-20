using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrees : MonoBehaviour
{
    private GameObject[] startTrees;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        startTrees = GameObject.FindGameObjectsWithTag("StartTrees");
    }

    // Update is called once per frame
    void Update()
    {
        
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
