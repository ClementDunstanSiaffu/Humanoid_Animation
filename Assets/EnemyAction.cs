using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex  = 0;
    private NavMeshAgent agent;
    public Transform player;
    private int _lives;

    public int EnemyLives{
        get{
            return _lives;
        }
        set{
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Enemy is down");
            }
        }
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolRoute = GameObject.Find("PatrolRoute").GetComponent<Transform>(); 
        player = GameObject.Find("Player").GetComponent<Transform>();
        Debug.Log(patrolRoute.position.ToString() + "from the start");
        InitializePatrolRoute();
        
    }
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            // Debug.Log("Move to next patrol is called");
            MovetoNextPatrolLocation();
        }
    }
    void InitializePatrolRoute(){
        foreach(Transform child in patrolRoute){
            locations.Add(child);
        }
    }
    void MovetoNextPatrolLocation(){
        // Debug.Log(agent.ToString() + "check agent value");
        if (locations.Count == 0)
            return;
        agent.SetDestination(locations[locationIndex].position);
        // agent.destination = locations[locationIndex].position;
        Debug.Log(locations[locationIndex].position.ToString());
        Debug.Log(agent.destination.ToString());
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    void OnTriggerEnter(Collider other){
        if (other.name == "Player"){
            agent.destination = player.position;
            Debug.Log("Player is detected - attack");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.name == "Player"){
            Debug.Log("Player is out of range - resume patrol");
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Bullet(Clone)"){
            EnemyLives-=1;
            Debug.Log("Enemy is hit");
        }
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
