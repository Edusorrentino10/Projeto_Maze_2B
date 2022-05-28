using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBallForward : MonoBehaviour
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
        // mantem a velocidade do objeto, com a diferença que é pra outra direção
        ballRigidbody.velocity = Vector3.back * speed;
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
