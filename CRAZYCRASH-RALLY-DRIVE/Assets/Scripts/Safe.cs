using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private GameObject fColliders;

    private MapControll mapControll;

    public bool activeSafe = false;

    public bool reBackSafe = false;

    public bool disableSafe = false;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        fColliders = GameObject.FindGameObjectWithTag("MapCfront");
        mapControll = fColliders.GetComponent<MapControll>();

        meshRenderer.enabled = false;
    }


    private void Update()
    {
        if (reBackSafe == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = false;
            reBackSafe = false;
        }

        if (activeSafe == true && disableSafe == false)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }
        if (activeSafe == false && disableSafe == true)
        {
            gameObject.SetActive(false);
            meshRenderer.enabled = false;
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
            meshRenderer.enabled = false;
            gameObject.SetActive(false);

            activeSafe = false;
            //isColliderUnActive = true;
        }
        /*if (collision.gameObject.CompareTag("MapCfront"))
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }*/
    }
}
