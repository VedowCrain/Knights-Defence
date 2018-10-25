using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private bool allowWonder;
    private Animator anim;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        timer = wanderTimer;
        allowWonder = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (allowWonder && timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        anim.SetFloat("Vertical", agent.velocity.magnitude);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void StopAgent()
    {
        agent.Stop();
        allowWonder = false;
    }

    public void ResumeAgent()
    {
        agent.Resume();
        allowWonder = true;
    }
}