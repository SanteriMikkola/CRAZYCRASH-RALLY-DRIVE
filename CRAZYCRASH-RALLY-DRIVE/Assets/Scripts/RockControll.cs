using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControll : MonoBehaviour
{
    private Este esteS;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        esteS = gameObject.GetComponent<Este>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (esteS.activateMesh == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }
    }
}
