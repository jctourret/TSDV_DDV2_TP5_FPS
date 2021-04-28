using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public int score = 0;
    public int health = 100;
    public int killCount = 0;
    public int ammo = 0;

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
    
    void Update()
    {
        if (currentScene.name == "Gameplay")
        {
            if(health <= 0)
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }
}
