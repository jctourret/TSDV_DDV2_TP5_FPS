using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Giver : MonoBehaviour
{
    int scoreGain = 50;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided");
        if (collider.tag == "Player")
        {
            Game_Manager.instance.score += scoreGain;
            Destroy(gameObject);
        }
    }
}
