
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSript : MonoBehaviour
{
    [HideInInspector] public static bool colliding = false;

    [SerializeField] List<GameObject> walkTo = new List<GameObject>();

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange, lookRange;
    public bool playerInSightRange, playerInLookRange;

    int walkToInt = 0;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Debug.Log(DialogueScript.colWait);

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInLookRange = Physics.CheckSphere(transform.position, lookRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        //if (playerInSightRange && !playerInLookRange) ChasePlayer();
        if (playerInLookRange) CloseToPlayer();
        if (!playerInLookRange || DialogueScript.colWait) NotColliding();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        for (int i = walkToInt; i < walkTo.Count; i++)
        {
            walkPoint = walkTo[i].transform.position;
            walkToInt += 1;
            if (walkToInt == walkTo.Count) walkToInt = 0;
            break;
        }
        if (Physics.Raycast(walkPoint, -transform.up, 4f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }

    private void CloseToPlayer()
    {
        if (!DialogueScript.colWait)
        {
            //Make sure enemy doesn't move
            agent.SetDestination(transform.position);

            transform.LookAt(player);

            colliding = true;
        }
    }

    private void NotColliding()
    {
        colliding = false;

        Invoke("WaitOff", 10f);
    }

    void WaitOff()
    {
        //Debug.Log("wait");
        DialogueScript.colWait = false;
    }
}
