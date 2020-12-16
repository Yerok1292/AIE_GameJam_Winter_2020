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
    public GameObject[] customerPrefab;
    private GameObject tempCustomer;
    public float spawnTimer = 5;
    private float spawnTime;
    public Vector3 spawnPoint;
    public int maxCustomers = 10;
    public int unmaskThreshold = 1;
    public int antiMaskChanceNumerator = 1;
    public int antiMaskChanceDenominator = 4;
    public int maskChanceNumerator = 3;
    public int maskChanceDenominator = 4;
    public int minTasks = 2;
    public int maxTasks = 6;

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
                    customer.Move(customer.tasks[customer.taskIndex].position);
                    break;
                case Customer.States.Interact:
                    customer.Interact();
                    break;
                case Customer.States.Leave:
                    customer.Leave(spawnPoint);
                    break;
            }
            if (customer.shouldDespawn)
            {
                DespawnCustomer(customer);
            }
        }
    }

    void SpawnCheck()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else if (customers.Count < maxCustomers)
        {
            bool antiMaskRand = false;
            bool maskedRand = false;
            if (Random.Range(0, 2) == 0)
            {
                antiMaskRand = false;
                if (Random.Range(0, maskChanceDenominator) < maskChanceNumerator - 1)
                {
                    maskedRand = true;
                }
                else
                {
                    maskedRand = false;
                }
            }
            else
            {
                antiMaskRand = true;
                if (Random.Range(0, antiMaskChanceDenominator) < antiMaskChanceNumerator - 1)
                {
                    maskedRand = true;
                }
                else
                {
                    maskedRand = false;
                }
            }

            Transform[] randomTasks = new Transform[Random.Range(minTasks, maxTasks + 1)];
            for (int i = 0; i < randomTasks.Length; i++)
            {
                if (i != randomTasks.Length - 1)
                {
                    int rand = Random.Range(0, 3 + (aisleNodes.Length / 2));
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
                        default:
                            randomTasks[i] = aisleNodes[Random.Range(0, aisleNodes.Length)];
                            break;
                    }
                }
                else
                {
                    randomTasks[i] = counterNode;
                }
            }

            GameObject customerObject = SpawnCustomer();
            Customer customerToAdd = new Customer(gameObject, antiMaskRand, maskedRand, customerObject, randomTasks);
            customers.Add(customerToAdd);

            spawnTime = spawnTimer;
        }
    }

    GameObject SpawnCustomer()
    {
        tempCustomer = customerPrefab[Random.Range(0, customerPrefab.Length)];
        GameObject custSpawn = Instantiate(tempCustomer, spawnPoint, new Quaternion());
        return custSpawn;
    }

    public void DespawnCustomer(Customer cust)
    {
        customers.Remove(cust);
        Destroy(cust.customer);
        cust = null;
    }
}


public class Customer
{
    public GameObject manager;
    public bool shouldDespawn;
    public bool isAntiMasker;
    public enum States { Move, Interact, Leave };
    public States state;
    public GameObject customer;
    public NavMeshAgent agent;
    public Transform[] tasks;
    public int taskIndex;
    public float taskTimer;
    public int tasksDone = 0;

    WearingMask maskScript;

    public Customer(GameObject customerManager, bool antiMask, bool masked, GameObject customerObject, Transform[] nodeTasks)
    {
        manager = customerManager;
        shouldDespawn = false;
        isAntiMasker = antiMask;
        customer = customerObject;
        agent = customerObject.GetComponent<NavMeshAgent>();
        tasks = nodeTasks;
        maskScript = customerObject.GetComponent<WearingMask>();
        maskScript.masked = masked;
    }

    public void Move(Vector3 target)
    {
        agent.SetDestination(target);
        if (Vector3.Distance(agent.transform.position, target) < 1.3f)
        {
            if (taskIndex < tasks.Length - 1)
            {
                taskIndex++;
                taskTimer = 2;
                state = States.Interact;
            }
            else
            {
                state = States.Leave;
            }
        }
    }

    public void Interact()
    {
        if (taskTimer > 0)
        {
            taskTimer -= Time.deltaTime;
        }
        else
        {
            if (isAntiMasker)
            {
                if (tasksDone < manager.GetComponent<CustomerAI>().unmaskThreshold - 1)
                {
                    tasksDone++;
                }
                else
                {
                    tasksDone = 0;
                    maskScript.UnMask();
                }
            }
            state = States.Move;
        }
    }

    public void Leave(Vector3 exit)
    {
        agent.SetDestination(exit);
        if (Vector3.Distance(agent.transform.position, exit) < 3)
        {
            shouldDespawn = true;
        }
    }
}
