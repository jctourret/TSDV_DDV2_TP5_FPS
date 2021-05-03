using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Gun : MonoBehaviour
{
    [SerializeField] float targetDistance;
    [SerializeField] float AllowedRange = 5;
    int pistolDamage = 0;
    int rayDrawDistance = 100;

    private void OnEnable()
    {
        Player_Character.shootGun += shootPistol;
    }
    private void OnDisable()
    {
        Player_Character.shootGun -= shootPistol;
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDrawDistance, Color.yellow);
    }
    void shootPistol()
    {
        RaycastHit shot;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            Debug.Log(shot.collider.name);
            IDamagable damaged = shot.collider.GetComponent<IDamagable>();
            if (targetDistance < AllowedRange && damaged != null)
            {
                damaged.takeDamage(pistolDamage);
            }
        }
    }
}
