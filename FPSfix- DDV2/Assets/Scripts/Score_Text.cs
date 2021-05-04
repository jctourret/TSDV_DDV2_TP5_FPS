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

    private void OnEnable()
    {
        Bomb.bombKilled += updateScoreText;
        Enemy.ghostKilled += updateScoreText;
        Point_Giver.pointPickUp += updateScoreText;
    }
    private void OnDisable()
    {
        Bomb.bombKilled -= updateScoreText;
        Enemy.ghostKilled -= updateScoreText;
        Point_Giver.pointPickUp -= updateScoreText;
    }
    void updateScoreText(int unused)
    {
        scoreText.text = "Score: " + Game_Manager.instance.score;
    }
}
