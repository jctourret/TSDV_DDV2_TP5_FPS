using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character : MonoBehaviour , IChaseable, IDamagable, IKillable
{
    public static event Action shootGun;
    private void Update()
    {
        if (Input.GetKeyDown("Fire1"))
        {
            shootGun?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        IPickable pickUp = collision.collider.GetComponent<IPickable>();
        if (pickUp != null)
        {
            pickUp.pickUp(0);
        }
    }
    public void takeDamage(float damage)
    {

    }
    public void killed() {
    
    }
}
