using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(playerTransform.position);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.name == "Player") {
            SceneManager.LoadScene(1);
        }
    }
}
