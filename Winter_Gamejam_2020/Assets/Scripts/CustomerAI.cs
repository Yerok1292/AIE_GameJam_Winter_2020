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
    public GameObject customerPrefab;
    public int customerCount;
    public float spawnTimer = 5;
    private float spawnTime;
    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        customers = new List<Customer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            GameObject customerToAdd = SpawnCustomer();
            bool antiMaskRand = false;
            bool maskedRand = false;
            List<Transform> randomTasks = new List<Transform>();
            if (Random.Range(0, 2) == 0)
            {
                antiMaskRand = false;
                if (Random.Range(0, 4) == 3)
                {
                    maskedRand = false;
                }
                else
                {
                    maskedRand = true;
                }
            }
            else
            {
                antiMaskRand = true;
                if (Random.Range(0, 4) == 3)
                {
                    maskedRand = true;
                }
                else
                {
                    maskedRand = false;
                }
            }
            customerToAdd = new Customer(antiMaskRand, maskedRand, custSpawn.GetComponent<NavMeshAgent>(), randomTasks);
            spawnTime = spawnTimer;
        }

        foreach (Customer customer in customers)
        {
            switch (customer.state)
            {
                case Customer.States.Move:

                    break;
                case Customer.States.Interact:

                    break;
            }
        }
    }

    GameObject SpawnCustomer()
    {
        GameObject custSpawn = Instantiate(customerPrefab, spawnPoint, new Quaternion());
        
        return custSpawn;
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
