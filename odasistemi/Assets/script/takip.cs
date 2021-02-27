using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class takip : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform npc;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = npc.position;
    }
}
