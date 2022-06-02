using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCarMoving : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;
    private GameObject frontCcollider;
    private MapControll mapControll;

    private GameObject[] ObsCar_L;
    private GameObject[] ObsCar_R;

    public Vector3 endPos;

    [HideInInspector]
    public Vector3 targetPos, startPos;

    public float speed = 0f;

    private bool i = false;

    [HideInInspector]
    public bool deactiveObs = false;

    private bool activateObs = true;


    public bool isColliderUnActive = false;
    public bool activateMesh = false;
    public bool reActivate = false;

    public bool disableMesh = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
        frontCcollider = GameObject.Find("FrontCollider");
        mapControll = frontCcollider.GetComponent<MapControll>();

        ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
        ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");

        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        targetPos = endPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (carCollider.start_ObsCarsMove)
        {
            /*if (activateObs)
            {
                for (int i = 0; i < ObsCar_L.Length; i++)
                {
                    ObsCar_L[i].SetActive(true);
                }
                for (int i = 0; i < ObsCar_R.Length; i++)
                {
                    ObsCar_R[i].SetActive(true);
                }
                activateObs = false;
            }*/
            activateObs = true;
            if (!mapControll.isGamePaused)
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
        }
        else if (carCollider.start_ObsCarsMove && mapControll.isGamePaused)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }
        else if (!carCollider.start_ObsCarsMove)
        {
            if (activateObs)
            {
                gameObject.SetActive(true);
                transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
                activateObs = false;
            }
            

            i = false;
            //activateObs = true;
        }

    }
    void Update()
    {
        /*if (deactiveObs)
        {
            for (int i = 0; i < ObsCar_L.Length; i++)
            {
                ObsCar_L[i].SetActive(false);
            }
            for (int i = 0; i < ObsCar_R.Length; i++)
            {
                ObsCar_R[i].SetActive(false);
            }
            deactiveObs = false;
        }*/

        if (activateMesh == true && disableMesh == false)
        {
            gameObject.SetActive(true);
            isColliderUnActive = false;
        }

        if (disableMesh == true && activateMesh == false && activateObs == false/* && carCollider.start_ObsCarsMove/* && activateObs == false*/)
        {
            gameObject.SetActive(false);
            isColliderUnActive = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapCback") && isColliderUnActive == false && gameObject.CompareTag("ObsCar_L") || collision.gameObject.CompareTag("MapCback") && isColliderUnActive == false && gameObject.CompareTag("ObsCar_R"))
        {
            gameObject.SetActive(false);
            isColliderUnActive = true;
            activateMesh = false;
        }
    }
}
