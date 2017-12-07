using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceGUI : MonoBehaviour
{
    public int kevinCurHealth, kevinMaxHealth;

    public Vector2 targetPos;

    // Enemy.curHealth change size inversely proportional to Player distance
    public GameObject player;
    public float targetDistance;

    void Update()
    {
        Distance();
    }

    // Update is called once per frame
    void LateUpdate() // Damage is done in Update, so best to do the Health GUI part in Late Update (occurs after Update) to avoid possible issues
    {
        targetPos = Camera.main.WorldToScreenPoint(transform.position);

        if (kevinCurHealth < 0)
        {
            kevinCurHealth = 0;
        }

        if (kevinCurHealth > kevinMaxHealth)
        {
            kevinCurHealth = kevinMaxHealth;
        }
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (targetDistance < 10f)
        {
            GUI.Box(new Rect(
                            (targetPos.x - .5f * scrW), (-targetPos.y + scrH * 8.5f),
                            (kevinCurHealth * scrW / kevinMaxHealth) / (targetDistance / 10), (scrH * .25f) / (targetDistance / 5f)
                            ), "");
        }
    }

    void Distance()
    {
        targetDistance = Vector3.Distance(player.transform.position, transform.position);
    }
}
