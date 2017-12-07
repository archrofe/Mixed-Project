using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();
    public bool showInv;
    public Item selectedItem;
    public int money;
    public GameObject player;
    public MouseLook mainCam;
    public Vector2 scrollPos;
    public GameObject wHand, curWeapon, wHead, wFoot;
    public float charCurHealth;

    // Use this for initialization
    void Start()
    {
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(102));
        inv.Add(ItemGen.CreateItem(103));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(203));
        inv.Add(ItemGen.CreateItem(204));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(206));
        inv.Add(ItemGen.CreateItem(207));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(209));
        inv.Add(ItemGen.CreateItem(210));
        inv.Add(ItemGen.CreateItem(300));
        inv.Add(ItemGen.CreateItem(301));
        inv.Add(ItemGen.CreateItem(500));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(800));

        wHead = GameObject.FindGameObjectWithTag("HeadHandler");
        wHand = GameObject.FindGameObjectWithTag("WeaponHandler");
        wFoot = GameObject.FindGameObjectWithTag("FootHandler");
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        charCurHealth = gameObject.GetComponent<CharacterHandler>().curHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            //turn back on char and cam movement/mouselook
            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<MouseLook>().enabled = true;
            mainCam.enabled = true;
            //lock and hide our cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return (false);
        }
        else
        {
            showInv = true;
            Time.timeScale = 0;
            //turn off char and cam movement/mouselook
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<MouseLook>().enabled = false;
            mainCam.enabled = false;
            //unlock and show our cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return (true);
        }
    }

    void OnGUI()
    {
        if (showInv)
        {
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;

            //Background for inventory labeled Inventory
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            //if less or equal to x items no scroll view
            if (inv.Count <= 35)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(.5f * scrW, .25f * scrH + i * (.25f * scrH), 3 * scrW, .25f * scrH), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            else//if more then we can scroll and add the same space according to the number of stuff we have

            {
                scrollPos = GUI.BeginScrollView(new Rect(0, 0, 6 * scrW, 9 * scrH), scrollPos, new Rect(0, 0, 0, 9 * scrH + ((inv.Count - 35) * .25f * scrH)), false, true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(.5f * scrW, .25f * scrH + i * (.25f * scrH), 3 * scrW, .25f * scrH), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
                GUI.EndScrollView();
            }
            if (selectedItem != null)
            {
                if (selectedItem.Type == ItemType.Food)
                {
                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value + "\n" + selectedItem.Heal);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);
                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, .25f * scrH), "Eat"))
                    {
                        Debug.Log("Yum Yum Yum I love " + selectedItem.Name);
                        charCurHealth = charCurHealth + selectedItem.Heal;
                        inv.Remove(selectedItem);
                        selectedItem = null;
                    }
                }
                if (selectedItem.Type == ItemType.Weapon)
                {
                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);
                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, .25f * scrH), "Equip"))
                    {
                        Debug.Log("Ahhhh my Mighty " + selectedItem.Name);
                        if (curWeapon != null)
                        {
                            Destroy(curWeapon);
                        }
                        curWeapon = Instantiate(Resources.Load("Prefabs/" + selectedItem.Mesh) as GameObject, wHand.transform.position, wHand.transform.rotation, wHand.transform);
                        selectedItem = null;
                    }
                }
                if (selectedItem.Type == ItemType.Apparel)
                {
                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);
                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, .25f * scrH), "Equip"))
                    {
                        Debug.Log("Ahhhh my Mighty " + selectedItem.Name);
                        if (curWeapon != null)
                        {
                            Destroy(curWeapon);
                        }
                        curWeapon = Instantiate(Resources.Load("Prefabs/" + selectedItem.Mesh) as GameObject, wHead.transform.position, wHead.transform.rotation, wHead.transform);
                        curWeapon = Instantiate(Resources.Load("Prefabs/" + selectedItem.Mesh) as GameObject, wFoot.transform.position, wFoot.transform.rotation, wFoot.transform);
                        selectedItem = null;
                    }
                }
                if (selectedItem.Type == ItemType.Crafting)
                {

                }
                if (selectedItem.Type == ItemType.Quest)
                {

                }
                if (selectedItem.Type == ItemType.Ingredients)
                {

                }
                if (selectedItem.Type == ItemType.Potions)
                {

                }
                if (selectedItem.Type == ItemType.Scrolls)
                {

                }
            }
        }
    }
}
