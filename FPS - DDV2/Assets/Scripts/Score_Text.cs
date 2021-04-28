using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Text : MonoBehaviour
{
    Text scoreText;
    
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        scoreText.text = "Score: " + Game_Manager.instance.score;
    }
}
