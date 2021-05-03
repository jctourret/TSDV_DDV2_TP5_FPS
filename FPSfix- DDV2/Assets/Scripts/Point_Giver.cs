using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Giver : MonoBehaviour
{
    int scoreGain = 50;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.collider.tag == "Player")
        {
            Game_Manager.instance.score += scoreGain;
            Destroy(gameObject);
        }
    }
}
