using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour, IDamagable, IKillable
{ 
    public static event Action<int> bombKilled;
    int scoreGain = 100;
    int damageDealed = 50;
    int explosionRadius = 10;
    float detonationTime = 3f;
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var gO in hitColliders)
        {
            IChaseable chased = gO.GetComponent<IChaseable>();
            if (chased != null) {
                StartCoroutine(explosionTimer());
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided"+collision.collider.name);
        IDamagable damaged = collision.collider.GetComponent<IDamagable>();
        if (damaged != null)
        {
            damaged.takeDamage(damageDealed);
            Destroy(gameObject);
        }
    }
    public void takeDamage(float damage) {
        killed();
    }
    public void killed() {
        Destroy(gameObject);
        bombKilled?.Invoke(scoreGain);
    }

    IEnumerator explosionTimer()
    {
        yield return new WaitForSeconds(detonationTime);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var gO in hitColliders)
        {
            if (gO.gameObject != gameObject)
            {
                IDamagable damaged = gO.GetComponent<IDamagable>();
                if (damaged != null && gO.tag =="Player")
                {
                    Debug.Log(gO.name);
                    damaged.takeDamage(damageDealed);
                    Destroy(gameObject);
                }
            }
        }
    }
}
