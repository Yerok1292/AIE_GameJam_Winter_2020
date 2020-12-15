using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public Transform[] aisleNodes;
    public Transform bathroomNode;
    public Transform counterNode;
    public Transform slusheeNode;

    public List<Customer> customers;
    public int customerCount;
    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCustomer()
    {

    }
}


public class Customer
{
    bool isAntiMasker;
    bool isMasked;
    public enum States { Move, Interact };
    public States state;
    public NavMeshAgent agent;
    public List<Transform> tasks;

    public Customer(bool antiMask, bool masked, NavMeshAgent customerAgent, List<Transform> nodeTasks)
    {
        isAntiMasker = antiMask;
        isMasked = masked;
        agent = customerAgent;
        tasks = nodeTasks;
    }
}
