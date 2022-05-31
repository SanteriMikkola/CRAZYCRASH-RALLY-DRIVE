using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class OptionsControl : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;

    public Dropdown ResDropdown;

    public Toggle FullscreenToggle;

    List<int> widths = new List<int>() { 2560, 1920, 1600, 1600, 1280, 1280, 1024, 800, 720 };
    List<int> heights = new List<int>() { 1440, 1080, 1200, 1024, 1024, 720, 768, 600, 480 };


    public Dropdown qualityDropdown;


    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();


        carCollider.LoadData();

        SetScreenSize(carCollider.screenRes);
        SetFullscreen(carCollider.fullscreen);
        SetQuality(carCollider.quality);

        ResDropdown.value = carCollider.screenRes;
        FullscreenToggle.isOn = carCollider.fullscreen;
        qualityDropdown.value = carCollider.quality;
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


    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, false);

        carCollider.quality = index;
        carCollider.SaveData();
        carCollider.LoadData();
    }
}
