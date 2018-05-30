using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public Transform target;
    NavMeshAgent nav;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Base").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = GetComponent<Enemy>().speed;
        nav.SetDestination(target.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isGameOver)
        {
            nav.speed = 0;
            return;
        }

        if (!nav.pathPending)
        {
            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                {
                   EndPath();
                }
            }
        }
    }

    void EndPath()
    {
        PlayerStats.Lifes--;
        SpawnController.enemysAlives--;
        Destroy(gameObject);
    }
}
