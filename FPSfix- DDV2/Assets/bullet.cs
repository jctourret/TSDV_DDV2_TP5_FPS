using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float damage = 10;
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damaged = collision.collider.GetComponent<IDamagable>();
        if (damaged != null && collision.collider.tag == "Ghost")
        {
            damaged.takeDamage(damage);
        }
    }
}
