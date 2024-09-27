
using System.Collections.Generic;
using TreeEditor;
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

    [SerializeField] private string npcID;  // Unique ID for each NPC
    [SerializeField] private string dialogueNodeName;  // Node name in the Yarn script

    private DialogueScript dialogueScript;
    [SerializeField] private ShowDialogue showDialogue;

    private void Start()
    {
        dialogueScript = FindObjectOfType<DialogueScript>();
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
        /*if (!playerInLookRange || DialogueScript.colWait) NotColliding();*/
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
        if(!DialogueScript.colWait)
        colliding = true;
        Debug.Log("dialouge node =" + dialogueNodeName + "npc id " + npcID);
        // Trigger the dialogue with this NPC using their unique ID and node name

        //showDialogue.PlayerLock();

        dialogueScript.StartDialogue(dialogueNodeName, npcID);

        agent.SetDestination(transform.position);
        transform.LookAt(player);

        /*        if (!DialogueScript.colWait)
                {
                    //Make sure enemy doesn't move
                    agent.SetDestination(transform.position);

                    transform.LookAt(player);

                    colliding = true;
                }*/
    }
}
