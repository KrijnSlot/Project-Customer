
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.AI;

public class NPCSript : MonoBehaviour
{
    [HideInInspector] public bool colliding = false;
    public bool collidingCheck = false;

    [SerializeField] List<GameObject> walkTo = new List<GameObject>();


    [SerializeField] UI ui;

    public NavMeshAgent agent;

    public Transform player;

    public int waitTime;
    bool waiting = false;
    float timer = 0;


    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange, lookRange;
    public bool playerInSightRange, playerInLookRange;

    int walkToInt = 0;

    [SerializeField] private ShowDialogue showDialogue;

    [SerializeField] FirstPersonCam fpc;

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
        else
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player.position);
        }
        //if (playerInSightRange && !playerInLookRange) ChasePlayer();
        if (playerInLookRange) CloseToPlayer();
        if (!playerInLookRange || ui.done) NotColliding();
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
        if (!waiting)
        {
            ui.npcscript = this;

            fpc.otherCol = this.gameObject.transform;
            colliding = true;
            collidingCheck = colliding;
            gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = false;
        }
        else
        {
            gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = true;
        }
        // Trigger the dialogue with this NPC using their unique ID and node name
    }

    private void NotColliding()
    {
        colliding = false;

        timer += Time.deltaTime;

        gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = true;

        if (timer >= waitTime)
        {
            WaitOff();
        }

    }

    private void WaitOff()
    {
        waiting = false;
        ui.done = false;
        timer = 0;
    }
}
