using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region Variables
    [Header("Bools")]
    public bool showOptions;
    public bool muteToggle;
    [Header("Keys")]
    public KeyCode[] keys;
    //public KeysNames[] keyEnum;
    public string[] keyNames;
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode crouch;
    public KeyCode sprint;
    public KeyCode interact;
    public KeyCode holdingKey;
    public string forwardLabel;
    public string backwardLabel;
    public string leftLabel;
    public string rightLabel;
    public string jumpLabel;
    public string crouchLabel;
    public string sprintLabel;
    public string interactLabel;
    public string holdingKeyLabel;
    [Header("Resolutions and Screen Elements")]
    public int index;
    public bool showRes;
    public bool fullScreenToggle;
    public int[] resX, resY;
    public float scrW, scrH;
    public Vector2 scrollPosRes;
    [Header("Other References")]
    public AudioSource music;
    public float volumeSlider, holdingVolume;
    public Light dirLight;
    public float brightnessSlider;
    //FindGUI
    [Header("Art")]
    public GUISkin menuSkin;
    public GUIStyle boxStyle;
    #endregion


    void Start()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;
        fullScreenToggle = true;

        //brightness
        dirLight = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();
        //mainMusic
        music = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        //mainMusic
        volumeSlider = music.volume;
        //brightness
        brightnessSlider = dirLight.intensity;

        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "LeftControl"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));

        forwardLabel = forward.ToString();
        backwardLabel = backward.ToString();
        leftLabel = left.ToString();
        rightLabel = right.ToString();
        jumpLabel = jump.ToString();
        crouchLabel = crouch.ToString();
        sprintLabel = sprint.ToString();
        interactLabel = interact.ToString();
    }

    void Update()
    {
        if (music != null) // mainMusic
        {
            if (muteToggle == false)
            {
                // mainMusic
                if (music.volume != volumeSlider)
                {
                    holdingVolume = volumeSlider;
                    // mainMusic
                    music.volume = volumeSlider;
                }
            }
            else
            {
                volumeSlider = 0;
                // mainMusic
                music.volume = 0;
            }
        }

        if (dirLight != null)//brightness
        {                           //brightness
            if (brightnessSlider != dirLight.intensity)
            {  // brightness
                dirLight.intensity = brightnessSlider;
            }
        }

    }
    void OnGUI()
    {
        if (!showOptions)//if we are on our Main Menu and not our Options
        {
            //FindGUI
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", boxStyle);//background
            //FindGUI
            GUI.skin = menuSkin;
            GUI.Box(new Rect(4 * scrW, 0.25f * scrH, 8 * scrW, 2 * scrH), "YEEEE");//title
            //Buttons
            if (GUI.Button(new Rect(6 * scrW, 4 * scrH, 4 * scrW, scrH), "Play"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(6 * scrW, 5 * scrH, 4 * scrW, scrH), "Options"))
            {
                showOptions = true;
            }
            //FindGUI
            //GUI.skin = null;
            if (GUI.Button(new Rect(6 * scrW, 6 * scrH, 4 * scrW, scrH), "Exit"))
            {
                Application.Quit();
            }
        }
        else if (showOptions)//if we are on our Options Menu!!!!!
        {
            //set our aspect shiz if screen size changes
            if (scrW != Screen.width / 16)
            {
                scrW = Screen.width / 16;
                scrH = Screen.height / 9;
            }
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//background
            GUI.Box(new Rect(4 * scrW, 0.25f * scrH, 8 * scrW, 2 * scrH), "Options");//title

            if (GUI.Button(new Rect(14.875f * scrW, 8.375f * scrH, scrW, 0.5f * scrH), "Back"))
            {
                showOptions = false;
            }

            #region KeyBinding

            GUI.Box(new Rect(8.75f * scrW, 1f * scrH, 6.25f * scrW, 1f * scrH), "Forward");
            GUI.Box(new Rect(8.75f * scrW, 2f * scrH, 6.25f * scrW, 1f * scrH), "Backward");
            GUI.Box(new Rect(8.75f * scrW, 3f * scrH, 6.25f * scrW, 1f * scrH), "Left");
            GUI.Box(new Rect(8.75f * scrW, 4f * scrH, 6.25f * scrW, 1f * scrH), "Right");
            GUI.Box(new Rect(8.75f * scrW, 5f * scrH, 6.25f * scrW, 1f * scrH), "Jump");
            GUI.Box(new Rect(8.75f * scrW, 6f * scrH, 6.25f * scrW, 1f * scrH), "Sprint");
            GUI.Box(new Rect(8.75f * scrW, 7f * scrH, 6.25f * scrW, 1f * scrH), "Crouch");
            GUI.Box(new Rect(8.75f * scrW, 8f * scrH, 6.25f * scrW, 1f * scrH), "Interact");

            if (GUI.Button(new Rect(8.75f * scrW, 1f * scrH, 6.25f * scrW, 1f * scrH), forwardLabel))
            {
                Forward();
            }
            Event e = Event.current;
            if (forward == KeyCode.None)
            {
                // if an event is triggered by a key press
                if (e.isKey)
                {
                    Debug.Log("Key Code:" + e.keyCode);
                    // if this key is not the same as the other keys
                    if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                    {
                        // set forward to the new key
                        forward = e.keyCode;
                        // set holding key to none
                        holdingKey = KeyCode.None;
                        // set back to last key
                        forwardLabel = forward.ToString();
                    }
                    else
                    {
                        // set forward back to waht the holding key is
                        forward = holdingKey;
                        // set holding key to non
                        holdingKey = KeyCode.None;
                        // set back to last key
                        forwardLabel = forward.ToString();
                    }
                }
            }

            if (GUI.Button(new Rect(8.75f * scrW, 2f * scrH, 6.25f * scrW, 1f * scrH), "S"))
            {

            }

            if (GUI.Button(new Rect(8.75f * scrW, 3f * scrH, 6.25f * scrW, 1f * scrH), "A"))
            {

            }

            if (GUI.Button(new Rect(8.75f * scrW, 4f * scrH, 6.25f * scrW, 1f * scrH), "D"))
            {

            }

            if (GUI.Button(new Rect(8.75f * scrW, 5f * scrH, 6.25f * scrW, 1f * scrH), "Space"))
            {

            }

            if (GUI.Button(new Rect(8.75f * scrW, 6f * scrH, 6.25f * scrW, 1f * scrH), "Shift"))
            {

            }

            if (GUI.Button(new Rect(8.75f * scrW, 7f * scrH, 6.25f * scrW, 1f * scrH), "Ctrl"))
            {

            }

            if (GUI.Button(new Rect(8.75f * scrW, 8f * scrH, 6.25f * scrW, 1f * scrH), "R"))
            {

            }

            #endregion
            #region Brightness and Audio
            int i = 0;
            GUI.Box(new Rect(0.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 0.5f * scrH), "Volume");//Label
            volumeSlider = GUI.HorizontalSlider(new Rect(2f * scrW, 3.125f * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 0.25f * scrH), volumeSlider, 0, 1);

            if (GUI.Button(new Rect(3.75f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 0.5f * scrW, 0.5f * scrH), "Mute"))//Label
            {
                ToggleVolume();
            }

            i++;
            GUI.Box(new Rect(0.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 0.5f * scrH), "Brightness");//Label
            brightnessSlider = GUI.HorizontalSlider(new Rect(2f * scrW, 3.125f * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 0.25f * scrH), brightnessSlider, 0, 1);
            #endregion
            #region Resolution and Screen
            i++;
            i++;
            if (GUI.Button(new Rect(0.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 0.5f * scrH), "Resolutions"))
            {
                showRes = !showRes;
            }
            if (GUI.Button(new Rect(2f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 0.5f * scrH), "Fullscreen"))
            {
                FullScreenToggle();
            }
            i++;
            if (showRes)
            {
                GUI.Box(new Rect(0.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 3.5f * scrH), "");

                scrollPosRes = GUI.BeginScrollView(new Rect(0.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 3.5f * scrH), scrollPosRes, new Rect(0, 0, 1.75f * scrW, 3.5f * scrH));

                for (int resSize = 0; resSize < resX.Length; resSize++)
                {
                    if (GUI.Button(new Rect(0f * scrW, 0 * scrH + resSize * (scrH * 0.5f), 1.75f * scrW, 0.5f * scrH), resX[resSize].ToString() + "x" + resY[resSize].ToString()))
                    {
                        Screen.SetResolution(resX[resSize], resY[resSize], fullScreenToggle);
                        showRes = false;
                    }
                }
                GUI.EndScrollView();
            }
            #endregion
        }
    }

    void Forward()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            // set forward to the new key
            holdingKey = forward;
            // set holding key to none
            forward = KeyCode.None;
            // set back to last key
            forwardLabel = forward.ToString();
        }
    }

    bool ToggleVolume()
    {
        if (muteToggle == true)
        {
            muteToggle = false;
            volumeSlider = holdingVolume;
            return false;
        }
        else
        {
            muteToggle = true;
            holdingVolume = volumeSlider;
            volumeSlider = 0;
            music.volume = 0;
            return true;
        }
    }

    bool FullScreenToggle()
    {
        if (fullScreenToggle)
        {
            fullScreenToggle = false;
            Screen.fullScreen = false;
            return false;
        }
        else
        {
            fullScreenToggle = true;
            Screen.fullScreen = true;
            return true;
        }
    }
}