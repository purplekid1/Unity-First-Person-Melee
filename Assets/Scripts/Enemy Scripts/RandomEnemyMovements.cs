using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important

public class RandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public EnemyManager Guard;
    public detectionClose TC;
    public float range; //radius of sphere
    public bool Running;
    public bool Walking;

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    
    void StartAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        TC = transform.GetComponentInChildren<detectionClose>();
        agent.speed = 5f;
        Running = false;
        Walking = false;
    }


    void Update()
    {
        movement();
        detection();
       
    }

    private void movement()
    {
        target = GameObject.Find("Player").transform;

        if (Guard.alertLevel == 100)
        {
            Walking = false;
            Running = true;
            agent.speed = 35f;
            agent.destination = target.position;

        }
        else if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
                Running = false;
                Walking = true;
                agent.speed = 5f;
            }
        }

    }
    
    private void detection()
    {
        if (TC.touchingCollider)
        {
            Walking = false;
            Running = true;
            Guard.alertLevel = 100;
        }
    }
    



    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    

}
