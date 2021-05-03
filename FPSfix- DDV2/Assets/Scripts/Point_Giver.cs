using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Giver : MonoBehaviour, IPickable
{
    public static event Action<int> pointPickUp;
    int scoreGain = 50;

    private void OnEnable()
    {
        pointPickUp += pickUp;
    }
    private void OnDisable()
    {
        pointPickUp -= pickUp;
    }
    public void pickUp(int unsused)
    {
        Destroy(gameObject);
        pointPickUp?.Invoke(scoreGain);
    }
}
