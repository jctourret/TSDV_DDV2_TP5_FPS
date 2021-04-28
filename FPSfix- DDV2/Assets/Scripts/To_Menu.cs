using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class To_Menu : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToMainMenu);
    }
    void Update()
    {

    }
    void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
