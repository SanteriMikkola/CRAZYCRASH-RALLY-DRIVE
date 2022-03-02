using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FewRocksControll : MonoBehaviour
{
    private Este esteS;
    private MeshRenderer[] meshRenderer;

    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        esteS = gameObject.GetComponent<Este>();

    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer = gameObject.GetComponentsInChildren<MeshRenderer>();
        //Debug.Log("Mesh Renderin pituus: " + meshRenderer.Length);
        if (esteS.activateMesh == true)
        {
            gameObject.SetActive(true);

            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = true;

                i++;
            }

            /*meshRenderer[1].enabled = true;
            meshRenderer[2].enabled = true;
            meshRenderer[3].enabled = true;
            meshRenderer[4].enabled = true;*/
            return;
        }
        return;
    }
}
