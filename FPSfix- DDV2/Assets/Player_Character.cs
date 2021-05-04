using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character : MonoBehaviour , IChaseable, IDamagable, IKillable
{
    float health = 1000f;

    public static event Action playerDeath;
    public static event Action shootEquippedGun;
    public static event Action<float> playerRecibesDamage;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootEquippedGun?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        IPickable pickUp = collision.collider.GetComponent<IPickable>();
        if (pickUp != null)
        {
            pickUp.pickUp(0);
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        playerRecibesDamage?.Invoke(health);
        if (health == 0)
        {
            killed();
        }
    }
    public void killed() {
        playerDeath?.Invoke();
    }
}
