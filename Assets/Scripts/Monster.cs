using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator ani;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Rigidbody rig;
    public Transform targetPos;
    public bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(targetPos.position);
        if (isdead == true)
        {
            navMeshAgent.isStopped = true;
            Destroy(gameObject);
        }
        if (rig.velocity.x >= 0 || rig.velocity.z >= 0)
        {
            ani.SetBool("isrun", true);
        }

        if (Vector3.Distance(targetPos.position, this.transform.position) <= 1)
        {
            navMeshAgent.isStopped = true;
            ani.SetTrigger("attack");

        }
    }

}


