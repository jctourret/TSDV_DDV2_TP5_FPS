using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    int scoreGain = 100;
    int bombDamage = 50;
    void OnDestroy()
    {
        Game_Manager.instance.score += scoreGain;
        Game_Manager.instance.killCount++;
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided");
        if (collider.tag == "Player") {
            Game_Manager.instance.health -= bombDamage;
            Destroy(gameObject);
        }
    }
}
