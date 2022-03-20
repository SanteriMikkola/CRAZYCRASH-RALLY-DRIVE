using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCan : MonoBehaviour
{
    private MeshRenderer[] meshRenderer;
    private GameObject fColliders;

    private MapControll mapControll;

    public bool activeJerryCan = false;
    public bool rebackJerry = false;

    private int i = 0;

    private void Start()
    {
        //meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer = gameObject.GetComponentsInChildren<MeshRenderer>();

        fColliders = GameObject.FindGameObjectWithTag("MapCfront");
        mapControll = fColliders.GetComponent<MapControll>();

        while (i != meshRenderer.Length)
        {
            meshRenderer[i].enabled = false;

            i++;
        }
        i = 0;
    }


    private void Update()
    {
        if (rebackJerry == true)
        {
            gameObject.SetActive(true);

            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = false;

                i++;
            }
            i = 0;
            rebackJerry = false;
        }

        if (activeJerryCan == true)
        {
            gameObject.SetActive(true);

            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = true;

                i++;
            }
            i = 0;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            this.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("MapCback"))
        {
            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = false;

                i++;
            }

            gameObject.SetActive(false);

            activeJerryCan = false;
            //isColliderUnActive = true;
        }
        /*if (collision.gameObject.CompareTag("MapCfront"))
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }*/
    }
}
