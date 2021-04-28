using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill_Count_Text : MonoBehaviour
{
    Text killText;

    void Start()
    {
        killText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        killText.text = "Kill Count: " + Game_Manager.instance.killCount;
    }
}
