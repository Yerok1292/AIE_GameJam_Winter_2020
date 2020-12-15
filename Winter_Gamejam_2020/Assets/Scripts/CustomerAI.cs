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
        SpawnCheck();

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

    void SpawnCheck()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            bool antiMaskRand = false;
            bool maskedRand = false;
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

            Transform[] randomTasks = new Transform[Random.Range(0, 7)];
            for (int i = 0; i < randomTasks.Length; i++)
            {
                if (i != randomTasks.Length - 1)
                {
                    int rand = Random.Range(0, 3);
                    switch (rand)
                    {
                        case 0:
                            randomTasks[i] = aisleNodes[Random.Range(0, aisleNodes.Length)];
                            break;
                        case 1:
                            randomTasks[i] = bathroomNode;
                            break;
                        case 2:
                            randomTasks[i] = slusheeNode;
                            break;
                    }
                }
            }

            GameObject customerObject = SpawnCustomer();
            Customer customerToAdd = new Customer(antiMaskRand, maskedRand, customerObject.GetComponent<NavMeshAgent>(), randomTasks);
            customers.Add(customerToAdd);
            spawnTime = spawnTimer;
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
    public Transform[] tasks;

    public Customer(bool antiMask, bool masked, NavMeshAgent customerAgent, Transform[] nodeTasks)
    {
        isAntiMasker = antiMask;
        isMasked = masked;
        agent = customerAgent;
        tasks = nodeTasks;
    }
}
