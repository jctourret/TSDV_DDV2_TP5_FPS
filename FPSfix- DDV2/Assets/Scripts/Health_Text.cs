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
    private void OnEnable()
    {
        Player_Character.playerRecibesDamage +=setHealth;
    }
    private void OnDisable()
    {
        Player_Character.playerRecibesDamage -=setHealth;
    }
    void setHealth(float health)
    {
        healthText.text = "Health: " + health;
    }
}
