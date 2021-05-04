using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour , IDamagable, IKillable
{
    public static event Action<int> ghostKilled;
    enum EnemyState {roaming,chasing, attacking}
    NavMeshAgent agent;

    float fovRadius = 5;
    float attackDamage = 10;
    float attackRange = 2;
    float roamingArea = 5;
    float attackSpeed = 10;
    float timer= 0;
    float health = 30;
    int scoreGain = 200;
    Vector3 walkPoint;
    [SerializeField] Vector3 target;

    bool roaming = true;
    bool attackCooldown = false;
    bool chasing = false;
    bool walkPointSet = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] chaseColliders = Physics.OverlapSphere(transform.position,fovRadius);
        foreach(var collider in chaseColliders)
        {
            IChaseable chased = collider.GetComponent<IChaseable>();
            if(chased != null && target !=null)
            {
                target = collider.transform.position;
                if (Vector3.Distance(transform.position, target) > 1f)
                {
                    agent.SetDestination(target);
                    transform.LookAt(target);
                    chasing = true;
                    roaming = false;
                }
            }
        }
        if (chasing && Vector3.Distance(transform.position, target) >= fovRadius)
        {
            agent.SetDestination(transform.position);
            chasing = false;
            roaming = true;
        }
        Collider[] attackColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var collider in attackColliders)
        {
            IDamagable damaged = collider.GetComponent<IDamagable>();
            if (damaged != null && collider.tag == "Player")
            {
                if (!attackCooldown) {
                    damaged.takeDamage(attackDamage);
                    attackCooldown = true;
                }
            }
        }
        if (roaming) {
            roam();
        }
        timer += Time.deltaTime;
        if (timer>=attackSpeed)
        {
            attackCooldown = false;
            timer = 0f;
        }
    }
    void roam()
    {
        if (!walkPointSet) { setWalkPoint(); };
        if (walkPointSet) { agent.SetDestination(walkPoint); }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    void setWalkPoint()
    {

        float x = UnityEngine.Random.Range(-roamingArea, roamingArea);
        float z = UnityEngine.Random.Range(-roamingArea, roamingArea);

        walkPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(walkPoint, -transform.up, 2f))
        {
            walkPointSet = true;
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killed();
        }
    }
    public void killed()
    {
        ghostKilled?.Invoke(scoreGain);
        Destroy(gameObject);
    }
}
