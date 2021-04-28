using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Gameplay : MonoBehaviour
{
   public void ToGameplay()
   {
        SceneManager.LoadScene("Gameplay");
   }
}
