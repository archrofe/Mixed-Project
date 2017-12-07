using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    [Header("Bools")]
    public bool gameScene;
    public bool showOptions;
    public bool pause;
    /* Setting bool/true of false
    public bool fullscreen;
    */

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

    [Header("References")]
    public GameObject menu;
    public GameObject options;
    public AudioSource mainMusic;
    public Slider musicSlider, brightnessSlider;
    public Light brightness;
    public Text forwardText, backwardText, leftText, rightText, jumpText, crouchText, sprintText, interactText;
    // Setting Toggle field to "fullScreen"
    public Toggle fullScreen;
    /* Setting Dropdown field to "resolution"
    public Dropdown resolution;
    */
    public bool fullScreenToggle;
    public CharacterHandler HUD;

    [Header("Resolutions")]
    public int index;
    public int[] resX, resY;
    public Dropdown resolutionDropdown;

    //Dropdown has a value variable that you can use to reference arrays

public void ResolutionChange()
    {
        index = resolutionDropdown.value;
        Screen.SetResolution(resX[index], resY[index], fullScreenToggle);
    }

    void Start()
    {
        /* Makes the build fullscreen
        fullscreen = true;
        // This is where we set the resolutions
        Screen.SetResolution(1024, 576, false);
        Screen.SetResolution(1152, 648, false);
        Screen.SetResolution(1280, 720, false);
        Screen.SetResolution(1366, 768, false);
        Screen.SetResolution(1600, 900, false);
        Screen.SetResolution(1920, 1080, false);
        Screen.SetResolution(2560, 1440, false);
        Screen.SetResolution(3840, 2160, false);
        Screen.SetResolution(1600, 1000, fullscreen);
        */
        if(gameScene)
        {
            HUD = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHandler>();
        }

        if (mainMusic != null && musicSlider != null)
        {
            if (PlayerPrefs.HasKey("Music"))
            {
                Load();
            }
            musicSlider.value = mainMusic.volume;
        }

        if (brightness != null && brightnessSlider != null)
        {
            if (PlayerPrefs.HasKey("Brightness"))
            {
                Load();
            }
            brightnessSlider.value = brightness.intensity;
        }

        #region Key Set Up
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "LeftControl"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));

        forwardText.text = forward.ToString();
        backwardText.text = backward.ToString();
        leftText.text = left.ToString();
        rightText.text = right.ToString();
        jumpText.text = jump.ToString();
        crouchText.text = crouch.ToString();
        sprintText.text = sprint.ToString();
        interactText.text = interact.ToString();
        #endregion

        #region Resolution
        index = PlayerPrefs.GetInt("Res", 3);
        int fullWindow = PlayerPrefs.GetInt("FullWindow", 1);
        if (fullWindow == 0)
        {
            fullScreenToggle = false;
            fullScreen.isOn = false;
        }

        else
        {
            fullScreenToggle = true;
            fullScreen.isOn = true;
        }

        resolutionDropdown.value = index;
        Screen.SetResolution(resX[index], resY[index], fullScreenToggle);
        Screen.fullScreen = fullScreenToggle;
        #endregion
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

    void Update()
    {
        if (mainMusic != null && musicSlider != null)
            if (musicSlider.value != mainMusic.volume)
            {
                mainMusic.volume = musicSlider.value;
            }

        if (brightness != null && brightnessSlider != null)
            if (brightnessSlider.value != brightness.intensity)
            {
                brightness.intensity = brightnessSlider.value;
            }

        if (gameScene)
        {

             // if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
                if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ShowOptions()
    {
        ToggleOptions();
    }
    public bool ToggleOptions()
    {
        if (showOptions)
        {
            showOptions = false;
            menu.SetActive(true);
            options.SetActive(false);
            return false;
        }
        else
        {
            showOptions = true;
            menu.SetActive(false);
            options.SetActive(true);
            return true;
        }
    }

    void OnGUI()
    {
        #region Set New Key or Set Key Back
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
                    forwardText.text = forward.ToString();
                }
                else
                {
                    // set forward back to waht the holding key is
                    forward = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    forwardText.text = forward.ToString();
                }
            }
        }
        if (backward == KeyCode.None)
        {
            // if an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code:" + e.keyCode);
                // if this key is not the same as the other keys
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    // set backward to the new key
                    backward = e.keyCode;
                    // set holding key to none
                    holdingKey = KeyCode.None;
                    // set back to last key
                    backwardText.text = backward.ToString();
                }
                else
                {
                    // set backward back to waht the holding key is
                    backward = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    backwardText.text = backward.ToString();
                }
            }
        }
        if (left == KeyCode.None)
        {
            // if an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code:" + e.keyCode);
                // if this key is not the same as the other keys
                if (!(e.keyCode == backward || e.keyCode == forward || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    // set left to the new key
                    left = e.keyCode;
                    // set holding key to none
                    holdingKey = KeyCode.None;
                    // set back to last key
                    leftText.text = left.ToString();
                }
                else
                {
                    // set left back to waht the holding key is
                    left = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    leftText.text = left.ToString();
                }
            }
        }
        if (right == KeyCode.None)
        {
            // if an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code:" + e.keyCode);
                // if this key is not the same as the other keys
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == forward || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    // set right to the new key
                    right = e.keyCode;
                    // set holding key to none
                    holdingKey = KeyCode.None;
                    // set back to last key
                    rightText.text = right.ToString();
                }
                else
                {
                    // set right back to waht the holding key is
                    right = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    rightText.text = right.ToString();
                }
            }
        }
        if (jump == KeyCode.None)
        {
            // if an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code:" + e.keyCode);
                // if this key is not the same as the other keys
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == forward || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    // set jump to the new key
                    jump = e.keyCode;
                    // set holding key to none
                    holdingKey = KeyCode.None;
                    // set back to last key
                    jumpText.text = jump.ToString();
                }
                else
                {
                    // set jump back to waht the holding key is
                    jump = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    jumpText.text = jump.ToString();
                }
            }
        }
        if (crouch == KeyCode.None)
        {
            // if an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code:" + e.keyCode);
                // if this key is not the same as the other keys
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == forward || e.keyCode == sprint || e.keyCode == interact))
                {
                    // set crouch to the new key
                    crouch = e.keyCode;
                    // set holding key to none
                    holdingKey = KeyCode.None;
                    // set back to last key
                    crouchText.text = crouch.ToString();
                }
                else
                {
                    // set crouch back to waht the holding key is
                    crouch = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    crouchText.text = crouch.ToString();
                }
            }
        }
        if (sprint == KeyCode.None)
        {
            // if an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code:" + e.keyCode);
                // if this key is not the same as the other keys
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == forward || e.keyCode == interact))
                {
                    // set sprint to the new key
                    sprint = e.keyCode;
                    // set holding key to none
                    holdingKey = KeyCode.None;
                    // set back to last key
                    sprintText.text = sprint.ToString();
                }
                else
                {
                    // set sprint back to waht the holding key is
                    sprint = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    sprintText.text = sprint.ToString();
                }
            }
        }
        if (interact == KeyCode.None)
        {
            // if an event is triggered by a key press
            if (e.isKey)
            {
                Debug.Log("Key Code:" + e.keyCode);
                // if this key is not the same as the other keys
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == forward))
                {
                    // set interact to the new key
                    interact = e.keyCode;
                    // set holding key to none
                    holdingKey = KeyCode.None;
                    // set back to last key
                    interactText.text = interact.ToString();
                }
                else
                {
                    // set interact back to waht the holding key is
                    interact = holdingKey;
                    // set holding key to non
                    holdingKey = KeyCode.None;
                    // set back to last key
                    interactText.text = interact.ToString();
                }
            }
        }
        #endregion
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Music", mainMusic.volume);
        PlayerPrefs.SetFloat("Brightness", brightness.intensity);
        PlayerPrefs.SetString("Forward", forward.ToString());
        PlayerPrefs.SetString("Backward", backward.ToString());
        PlayerPrefs.SetString("Left", left.ToString());
        PlayerPrefs.SetString("Right", right.ToString());
        PlayerPrefs.SetString("Jump", jump.ToString());
        PlayerPrefs.SetString("Crouch", crouch.ToString());
        PlayerPrefs.SetString("Sprint", sprint.ToString());
        PlayerPrefs.SetString("Interact", interact.ToString());
        /*PlayerPrefs.SetString("Res", resolution.ToString());
        */
        // Resolution
        PlayerPrefs.SetInt("ResX", index);
        PlayerPrefs.SetInt("ResY", index);
        if (fullScreenToggle)
        {
            PlayerPrefs.SetInt("FullWindow", 1);
        }

        else
        {
            PlayerPrefs.SetInt("FullWindow", 0);
        }

    }

    public void Load()
    {
        mainMusic.volume = PlayerPrefs.GetFloat("Music");
        brightness.intensity = PlayerPrefs.GetFloat("Brightness");
        forwardText.text = PlayerPrefs.GetString("Forward");
        backwardText.text = PlayerPrefs.GetString("Backward");
        leftText.text = PlayerPrefs.GetString("Left");
        rightText.text = PlayerPrefs.GetString("Right");
        jumpText.text = PlayerPrefs.GetString("Jump");
        crouchText.text = PlayerPrefs.GetString("Crouch");
        sprintText.text = PlayerPrefs.GetString("Sprint");
        interactText.text = PlayerPrefs.GetString("Interact");
    }

    #region Controls
    public void Forward()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = forward;
            // set this button to none allowing us to edit only this button
            forward = KeyCode.None;
            // set the GUI to blank
            forwardText.text = forward.ToString();
        }
    }

    public void Backward()
    {
        if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = backward;
            // set this button to none allowing us to edit only this button
            backward = KeyCode.None;
            // set the GUI to blank
            backwardText.text = backward.ToString();
        }
    }

    public void Left()
    {
        if (!(backward == KeyCode.None || forward == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = left;
            // set this button to none allowing us to edit only this button
            left = KeyCode.None;
            // set the GUI to blank
            leftText.text = left.ToString();
        }
    }

    public void Right()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || forward == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = right;
            // set this button to none allowing us to edit only this button
            right = KeyCode.None;
            // set the GUI to blank
            rightText.text = right.ToString();
        }
    }

    public void Jump()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || forward == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = jump;
            // set this button to none allowing us to edit only this button
            jump = KeyCode.None;
            // set the GUI to blank
            jumpText.text = jump.ToString();
        }
    }

    public void Crouch()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || forward == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = crouch;
            // set this button to none allowing us to edit only this button
            crouch = KeyCode.None;
            // set the GUI to blank
            crouchText.text = crouch.ToString();
        }
    }

    public void Sprint()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || forward == KeyCode.None || interact == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = sprint;
            // set this button to none allowing us to edit only this button
            sprint = KeyCode.None;
            // set the GUI to blank
            sprintText.text = sprint.ToString();
        }
    }

    public void Interact()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || forward == KeyCode.None))
        {
            // set our holding key to the key of this button
            holdingKey = interact;
            // set this button to none allowing us to edit only this button
            interact = KeyCode.None;
            // set the GUI to blank
            interactText.text = interact.ToString();
        }
    }
    #endregion

     //Named the function ScreenToggle
    public void ScreenToggle()
    {
        // Once enabled it flips
        Screen.fullScreen = !Screen.fullScreen;
        // Ensures ScreenToggle works with fullscreen bool
        fullScreenToggle = !fullScreenToggle;
        Screen.fullScreen = fullScreenToggle;
    }
    /*
    // Named the function reDrop
    public void resDrop()
    {
        // References the Option names in the Dropdown componenet
        switch (resolution.captionText.text)
        {
            // Each case name is matches Option name and displays resolution
            case "1024×576 16:9":
                Screen.SetResolution(1024, 576, fullscreen);
                break;
            case "1152×648 16:9":
                Screen.SetResolution(1152, 648, fullscreen);
                break;
            case "1280×720 16:9":
                Screen.SetResolution(1280, 720, fullscreen);
                break;
            case "1366×768 16:9":
                Screen.SetResolution(1366, 768, fullscreen);
                break;
            case "1600×900 16:9":
                Screen.SetResolution(1600, 900, fullscreen);
                break;
            case "1920×1080 16:9":
                Screen.SetResolution(1920, 1080, fullscreen);
                break;
            case "2560×1440 16:9":
                Screen.SetResolution(2560, 1440, fullscreen);
                break;
            case "3840×2160 16:9":
                Screen.SetResolution(3840, 2160, fullscreen);
                break;
            // This is the defualt set resolution
            default:
                Screen.SetResolution(1600, 1000, fullscreen);
                break;
                */
        }