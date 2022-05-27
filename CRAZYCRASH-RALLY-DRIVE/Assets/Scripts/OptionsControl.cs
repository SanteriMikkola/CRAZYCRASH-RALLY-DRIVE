using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsControl : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;

    public Dropdown ResDropdown;

    public Toggle FullscreenToggle;

    List<int> widths = new List<int>() { 2560, 1920, 1920, 1600, 1600, 1400, 1280, 1280, 1280, 1280, 1024, 800, 720, 640 };
    List<int> heights = new List<int>() { 1440, 1440, 1080, 1200, 1024, 900, 1024, 960, 800, 720, 768, 600, 480, 480 };


    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();


        carCollider.LoadData();

        SetScreenSize(carCollider.screenRes);
        SetFullscreen(carCollider.fullscreen);

        ResDropdown.value = carCollider.screenRes;
        FullscreenToggle.isOn = carCollider.fullscreen;
    }

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);

        carCollider.screenRes = index;
        carCollider.SaveData();
        carCollider.LoadData();
    }

    public void SetFullscreen(bool IsThatfullscreen)
    {
        Screen.fullScreen = IsThatfullscreen;

        carCollider.fullscreen = IsThatfullscreen;
        carCollider.SaveData();
        carCollider.LoadData();
    }
}
