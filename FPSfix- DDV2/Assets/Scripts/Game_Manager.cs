using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public int score = 0;
    public int killCount = 0;
    public int ammo = 0;

    int highScore = 0;

    Scene currentScene;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        currentScene = SceneManager.GetActiveScene();
    }
    private void OnEnable()
    {
        Bomb.bombKilled += updateScore;
        Bomb.bombKilled += updateKillCount;
        Point_Giver.pointPickUp += updateScore;
        Player_Character.playerDeath += goToCredits;
    }
    private void OnDisable()
    {
        Bomb.bombKilled -= updateScore;
        Bomb.bombKilled -= updateKillCount;
        Point_Giver.pointPickUp -= updateScore;
        Player_Character.playerDeath -= goToCredits;
    }
    void updateScore(int scoreAdded)
    {
        score += scoreAdded;
    }
    void updateKillCount(int unused)
    {
        killCount++;
    }
    void goToCredits()
    {
        if (currentScene.name == "Gameplay")
        {
            if (highScore < score)
            {
                highScore = score;
            }
            SceneManager.LoadScene("Credits");
        }
    }
}