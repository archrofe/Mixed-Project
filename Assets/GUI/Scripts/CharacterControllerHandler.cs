using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <= for Canvas

public class CharacterControllerHandler : MonoBehaviour
{
    public bool dead; // Bool to check if Dead (True) or Alive (False)

    public float maxHealth, curHealth; // Health Bar needs Max Health and Current Health.
    public float maxStamina, curStamina; // Stamina Bar needs Max Stamina and Current Stamina
    public float maxMana, curMana; // Mana!

    public int level, maxExp, curExp;

    public GUIStyle healthBarRed;
    public GUIStyle manaBarBlue;
    public GUIStyle expBarOrange;

    public Slider staminaSlider;

    // Use this for initialization
    void Start()
    {
        maxHealth = 100f; // Start of Game, Max Health = 100
        curHealth = maxHealth; // At start of game, Current Health must equal Max Health (which was set above to 100)
        maxStamina = 100f;
        curStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = curStamina;
        maxMana = 100f;
        curMana = maxMana;
        maxExp = 60;

    }

    void Update()
    {
        if (staminaSlider.maxValue != maxStamina)
        {
            staminaSlider.maxValue = maxStamina;
        }
        if (staminaSlider.value != curStamina)
        {
            staminaSlider.value = curStamina;
        }

        // LEVELS
        if (curExp >= maxExp)
        {
            curExp -= maxExp; // curExp > maxExp? then subtract maxExp from Current Exp
            level++;
            maxHealth += 10;
            maxStamina += 7;
            maxMana += 5;
            maxExp += 50;
        }
    }


    
    void LateUpdate() // happens after Update in same frame as Update
    {
        // HEALTH:
        if(curHealth > maxHealth) // we want to make sure curHealth does not go above maxHealth
        {
            curHealth = maxHealth; // 
        }
        if(curHealth <= 0 && !dead) // IF curHealth <= 0 and state is NOT DEAD then make DEAD
        {
            curHealth = 0; // Current Health not to go below 0
            dead = true; // State changed to DEAD
        }
        else if(curHealth < 0) // backup for above?
        {
            curHealth = 0;
        }

        // STAMINA (no DEAD states)
        if(curStamina > maxStamina)
        {
            curStamina = maxStamina;
        }
        if(curStamina <= 0)
        {
            curStamina = 0;
        }

        // MANA (no DEAD states)
        if(curMana > maxMana)
        {
            curMana = maxMana;
        }
        if(curMana < 0)
        {
            curMana = 0;
        }
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16; // Dividing Screen Width into 16 parts, value of scrW = 1
        float scrH = Screen.height / 9; // Dividing Screen Height into 9 parts, value of scrH = 1

        // GUI element type Box
        // new Rect meaning New Rectangular position
        // x Start Point, y Start Point
        // x Size, y Size
        // Elements content
        // GUI.Box(new Rect(scrW, scrH, scrW, scrH), "Health");
        GUI.Box(new Rect(6f*scrW, scrH, 4*scrW, 0.5f*scrH), "HEALTH"); // he "scrW" and "scrH" equals 1 divided part from above. * (multiply) these to move position <= this is BACKGROUND
        // 

        // Health Bar
        GUI.Box(new Rect(6f*scrW, scrH, curHealth*(4*scrW)/maxHealth, 0.5f*scrH), "", healthBarRed); // 

        // MANA!
        GUI.Box(new Rect(1f * scrW, scrH, 4 * scrW, 0.5f * scrH), "MANA");
        GUI.Box(new Rect(1f * scrW, scrH, curMana * (4 * scrW) / maxMana, 0.5f * scrH), "", manaBarBlue);

        // Experience!
        GUI.Box(new Rect(6f * scrW, 8 * scrH, 4 * scrW, 0.5f * scrH), "XP");
        GUI.Box(new Rect(6f * scrW, 8 * scrH, curMana * (4 * scrW) / maxMana, 0.5f * scrH), "", expBarOrange);
    }
        
}
