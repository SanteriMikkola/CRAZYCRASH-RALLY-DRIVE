using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.SceneManagement;

public class NooraButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("koodi l�ytyy");
    }

    public void buttonPress()
    {
        SceneManager.LoadScene("TestScene");
    }

}
