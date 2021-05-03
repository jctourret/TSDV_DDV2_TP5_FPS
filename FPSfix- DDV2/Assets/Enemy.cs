using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    float fovRadius = 5;
    float RoamingArea = 5;
    [SerializeField]Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position,fovRadius);
        foreach(var collider in colliders)
        {
            IChaseable chased = collider.GetComponent<IChaseable>();
            if(chased != null && target !=null)
            {
                target = collider.transform.position;
                agent.SetDestination(target);
            }
        }
        if (Vector3.Distance(transform.position, target) > fovRadius)
        {
            agent.SetDestination(transform.position);
        }   
    }
}
