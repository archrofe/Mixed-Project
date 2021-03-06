﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
using UnityEngine.SceneManagement;

public class CustomisationSet : MonoBehaviour
{
    #region Variables
    //[Header("Texture List")]
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();

    //[Header("Index")]
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex;
    public int mouthIndex;
    public int eyesIndex;
    public int armourIndex;
    public int clothesIndex;

    //[Header("Renderer")]
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public SkinnedMeshRenderer character;

    //[Header("Max Index")]
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax;
    public int mouthMax;
    public int eyesMax;
    public int armourMax;
    public int clothesMax;

    //[Header("Character Name")]
    [Header("Character Name")]
    //name of our character that the user is making
    public string charName = "Adventurer";
    #endregion

    #region Start
    //in start we need to set up the following
    void Start()
    {

        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of hair textures we need
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of mouth textures we need
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of eyes textures we need
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of armour textures we need
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Armour_#
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the armour List
            armour.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of clothes textures we need
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Clothes_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the clothes List
            clothes.Add(temp);
        }
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();

        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Hair", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Armour", 0);
        SetTexture("Clothes", 0);
        #endregion
    }
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    void SetTexture(string type, int dir)
    {
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        //inside a switch statement that is swapped by the string name of our material
        switch(type)
        {
            //case skin
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index element number is 1
                matIndex = 1;
                //break
                break;

            //now repeat for each material 

            //hair is 2
            case "Hair":
                //index is the same as our hair index
                index = hairIndex;
                //max is the same as our hair max
                max = hairMax;
                //textures is our hair list .ToArray()
                textures = hair.ToArray();
                //material index element number is 2
                matIndex = 2;
                //break
                break;

            //mouth is 3
            case "Mouth":
                //index is the same as our mouth index
                index = mouthIndex;
                //max is the same as our mouth max
                max = mouthMax;
                //textures is our mouth list .ToArray()
                textures = mouth.ToArray();
                //material index element number is 3
                matIndex = 3;
                //break
                break;

            //eyes are 4
            case "Eyes":
                //index is the same as our eyes index
                index = eyesIndex;
                //max is the same as our eyes max
                max = eyesMax;
                //textures is our eyes list .ToArray()
                textures = eyes.ToArray();
                //material index element number is 4
                matIndex = 4;
                //break
                break;

            //armour are 5
            case "Armour":
                //index is the same as our armour index
                index = armourIndex;
                //max is the same as our armour max
                max = armourMax;
                //textures is our armour list .ToArray()
                textures = armour.ToArray();
                //material index element number is 5
                matIndex = 5;
                //break
                break;

            //eyes are 6
            case "Clothes":
                //index is the same as our clothes index
                index = clothesIndex;
                //max is the same as our clothes max
                max = clothesMax;
                //textures is our eyes list .ToArray()
                textures = clothes.ToArray();
                //material index element number is 6
                matIndex = 6;
                //break
                break;
        }

        //outside our switch statement
        //index plus equals our direction
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }

        if (index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        character.materials = mat;
        //create another switch that is goverened by the same string name of our material
        switch(type)
        {
            //case skin
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                //break
                break;

            //same thing for Hair, Mouth and Eyes

            //case hair
            case "Hair":
                //hair index equals our index
                hairIndex = index;
                //break
                break;

            //case mouth
            case "Mouth":
                //mouth index equals our index
                mouthIndex = index;
                //break
                break;

            //case eyes
            case "Eyes":
                //eyes index equals our index
                eyesIndex = index;
                //break
                break;

            //case armour
            case "Armour":
                //armour index equals our index
                armourIndex = index;
                //break
                break;

            //case clothes
            case "Clothes":
                //clothes index equals our index
                clothesIndex = index;
                //break
                break;
        }
    }
    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes to PlayerPrefs
    void Save()
    {
        //SetInt for SkinIndex, HairIndex, MouthIndex, Eyesindex
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        //SetString CharacterName
        PlayerPrefs.SetString("CharacterName", charName);
    }
    #endregion

    #region OnGUI
    //Function for our GUI elements
    void OnGUI()
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        //create an int that will help with shuffling your GUI elements under eachother
        int i = 0;
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i *(.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Skin", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Skin");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Skin", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        //set up same things for Hair, Mouth and Eyes
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Hair", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Hair");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Hair", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Mouth", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Mouth");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Mouth", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Eyes", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Eyes");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Eyes", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Armour", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Armour");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Armour", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Clothes", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Clothes");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Clothes", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction and reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Random"))
        {
            SetTexture("Skin", Random.Range(0, skinMax - 1));
            SetTexture("Hair", Random.Range(0, hairMax - 1));
            SetTexture("Mouth", Random.Range(0, mouthMax - 1));
            SetTexture("Eyes", Random.Range(0, eyesMax - 1));
            SetTexture("Armour", Random.Range(0, armourMax - 1));
            SetTexture("Clothes", Random.Range(0, clothesMax - 1));
        }
        //reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Armour", armourIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        charName = GUI.TextField(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 2 * scrW, .5f * scrH), charName, 12);
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Strength", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Strength");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Strength", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Dexterity", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Dexterity");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Dexterity", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Constituion", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Constituion");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Constituion", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Intelligence", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Intelligence");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Intelligence", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Wisdom", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Wisdom");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Wisdom", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Charisma", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Charisma");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), .5f * scrW, .5f * scrH), ">"))
        {
            SetTexture("Charisma", 1);
        }
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        i++;

        //GUI Button called Save and Play
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 2 * scrW, .5f * scrH), "Save & Play"))
        {
            //this button will run the save function and also load into the game level
            Save();
            SceneManager.LoadScene("Town");
        }
    }
    #endregion
}
