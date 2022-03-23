using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizePosOffset : MonoBehaviour
{
    public float offsetRange;

    
    void Start()
    {
        RandomizePos();
    }

    
    public void RandomizePos()
    {
        if (transform.parent != null)
        {
            transform.position = new Vector3(transform.parent.position.x + Random.Range(-offsetRange, offsetRange), transform.position.y, transform.parent.position.z + Random.Range(-offsetRange, offsetRange));
        }
    }
}
