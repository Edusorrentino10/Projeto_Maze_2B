using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public Door doorTerrainRoom;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LockBall(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            doorTerrainRoom.Open();
            LockBall(other.gameObject);
        }
    }


}
