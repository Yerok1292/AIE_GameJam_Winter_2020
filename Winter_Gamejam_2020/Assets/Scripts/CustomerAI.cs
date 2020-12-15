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

            Transform[] randomTasks = new Transform[Random.Range(2, 7)];
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
                else
                {
                    randomTasks[i] = counterNode;
                }
            }

            GameObject customerObject = SpawnCustomer();
            Customer customerToAdd = new Customer(antiMaskRand, maskedRand, customerObject, customerObject.GetComponent<NavMeshAgent>(), randomTasks);
            customers.Add(customerToAdd);

            spawnTime = spawnTimer;
        }
    }

    GameObject SpawnCustomer()
    {
        GameObject custSpawn = Instantiate(customerPrefab, spawnPoint, new Quaternion());
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
    public bool shouldDespawn;
    public bool isAntiMasker;
    public bool isMasked;
    public enum States { Move, Interact, Leave };
    public States state;
    public GameObject customer;
    public NavMeshAgent agent;
    public Transform[] tasks;
    public int taskIndex;
    public float taskTimer;

    public Customer(bool antiMask, bool masked, GameObject customerObject, NavMeshAgent customerAgent, Transform[] nodeTasks)
    {
        shouldDespawn = false;
        isAntiMasker = antiMask;
        isMasked = masked;
        customer = customerObject;
        agent = customerAgent;
        tasks = nodeTasks;
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
