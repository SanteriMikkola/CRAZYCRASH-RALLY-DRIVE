using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private GameObject fColliders;

    private MapControll mapControll;

    public bool activeToolBox = false;

    public bool reBackTB = false;

    public bool disableToolBox = false;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        fColliders = GameObject.FindGameObjectWithTag("MapCfront");
        mapControll = fColliders.GetComponent<MapControll>();

        meshRenderer.enabled = false;
    }


    private void Update()
    {
        if (reBackTB == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = false;
            reBackTB = false;
        }

        if (activeToolBox == true && disableToolBox == false)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }
        if (activeToolBox == false && disableToolBox == true)
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

            activeToolBox = false;
            //isColliderUnActive = true;
        }
        /*if (collision.gameObject.CompareTag("MapCfront"))
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }*/
    }
}
