using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Text : MonoBehaviour
{
    Text healthText;
    void Start()
    {
        healthText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        healthText.text = "Health: " + Game_Manager.instance.health;
    }
}
