using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCarMoving : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;
    private GameObject frontCcollider;
    private MapControll mapControll;

    public Vector3 endPos;

    [HideInInspector]
    public Vector3 targetPos, startPos;

    public float speed = 0f;

    private bool i = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
        frontCcollider = GameObject.Find("FrontCollider");
        mapControll = frontCcollider.GetComponent<MapControll>();

        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        targetPos = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (carCollider.start_ObsCarsMove && !mapControll.isGamePaused)
        {
            if (!i)
            {
                speed += 0.25f;
                i = true;
            }

            if (transform.position == endPos)
            {
                transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
            }
            if (transform.position == startPos)
            {
                targetPos = endPos;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(startPos.x, startPos.y, startPos.z);

            i = false;
        }

    }
}
