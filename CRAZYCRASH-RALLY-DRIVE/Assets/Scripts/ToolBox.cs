using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            
            this.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("MapCback"))
        {
            gameObject.SetActive(false);
            //isColliderUnActive = true;
        }
    }
}
