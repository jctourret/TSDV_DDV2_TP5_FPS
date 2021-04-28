using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Gun : MonoBehaviour
{
    [SerializeField] float targetDistance;
    [SerializeField] float AllowedRange = 5;
    int rayDrawDistance = 100;
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDrawDistance, Color.yellow);
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit shot;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;
                if (targetDistance < AllowedRange && shot.collider.tag == "Bomb")
                {
                   Destroy(shot.collider.gameObject);
                }
            }
        }
    }
}
