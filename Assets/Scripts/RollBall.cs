using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBall : MonoBehaviour
{
    Rigidbody ballRigidbody;

    [SerializeField] float speed = 25f;

    private void Awake()
    {
        // Pega a referência do Rigibody do objeto
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // mantem a velocidade do objeto
        ballRigidbody.velocity = Vector3.right * speed;
    }

    // Se ele entrar num trigger com a tag "Destroy" o objeto é destroido
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
