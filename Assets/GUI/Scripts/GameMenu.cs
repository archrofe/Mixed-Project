using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [Header("ScreenElements")]
    public bool gameScene;
    public bool showOptions;
    public bool pause;
    public int scrW, scrH;

    [Header("Keys")]
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode crouch;
    public KeyCode sprint;
    public KeyCode interact;
    public KeyCode holdingKey;

    [Header("Resolutions")]
    public int index;
    public int[] resX, resY;

    [Header("References")]
    public GameObject menu;
    public GameObject options;
    public AudioSource mainMusic;
    public float volumeSlider;
    public Light brightness;
    public float brightnessSlider;
    public float StaminaSlider;
    public CharacterHandler HUD;

    void Start()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;

        if (gameScene)
        {
            HUD = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHandler>();
        }
    }

    void Update()
    {
        if (gameScene)
        {
            // if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
    }

    public bool TogglePause()
    {
        if (pause)
        {
            if (!showOptions)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                menu.SetActive(false);
                pause = false;
                HUD.enabled = true;

            }
            else
            {
                showOptions = false;
                options.SetActive(false);
                menu.SetActive(true);
            }
            return false;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pause = true;
            menu.SetActive(true);
            HUD.enabled = false;

            return true;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        int i = 0;
        StaminaSlider = GUI.HorizontalSlider(new Rect(1 * scrW, 8.25f * scrH + (i * .75f * scrH), 2f * scrW, .25f * scrH), StaminaSlider, 0, 1);

        if (!showOptions) // If we are on our menu
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), ""); // Background box
            GUI.Box(new Rect(4 * scrW, .25f * scrH, 8 * scrW, 2 * scrH), "Intro to GUI");
            // Buttons
            if (GUI.Button(new Rect(6 * scrW, 4 * scrH, 4 * scrW, scrH), "Resume"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(6 * scrW, 5 * scrH, 4 * scrW, scrH), "Options"))
            {
                showOptions = !showOptions;
            }
            if (GUI.Button(new Rect(6 * scrW, 6 * scrH, 4 * scrW, scrH), "Leave Game"))
            {
                SceneManager.LoadScene(0);
            }

        }

        if (showOptions)
        {
            if (scrW != Screen.width / 16)
            {
                scrW = Screen.width / 16;
                scrH = Screen.height / 9;
            }

            if (GUI.Button(new Rect(6 * scrW, 4 * scrH, 4 * scrW, scrH), "Back"))
            {
                showOptions = !showOptions;
            }

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(4 * scrW, .25f * scrH, 8 * scrW, 2 * scrH), "Options");

            GUI.Box(new Rect(.5f * scrW, 3 * scrH + (i * .75f * scrH), 1.5f * scrW, .75f * scrH), "Volume");
            volumeSlider = GUI.HorizontalSlider(new Rect(2 * scrW, 3.25f * scrH + (i * .75f * scrH), 2f * scrW, .25f * scrH), volumeSlider, 0, 1);
            i++;
            GUI.Box(new Rect(.5f * scrW, 3 * scrH + (i * .75f * scrH), 1.5f * scrW, .75f * scrH), "Brightness");
            brightnessSlider = GUI.HorizontalSlider(new Rect(2 * scrW, 3.25f * scrH + (i * .75f * scrH), 2f * scrW, .25f * scrH), brightnessSlider, 0, 1);
        }
    }
}
