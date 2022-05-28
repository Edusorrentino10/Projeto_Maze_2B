using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject topOfTheDoor;
    public GameObject bottomOfTheDoor;

    IEnumerator CurrentCO_OpeningDoor;

    //Y == 2

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CO_OpeningDoor()
    {
        while (topOfTheDoor.transform.position.y > 2)
        {
            topOfTheDoor.transform.position += Vector3.up * Time.deltaTime;
            bottomOfTheDoor.transform.position -= Vector3.up * Time.deltaTime;
            yield return null;
        }
        Debug.Log("Terminou de Abrir");
    }

    public void Open()
    {
        if (CurrentCO_OpeningDoor != null)
        {
            StopCoroutine(CurrentCO_OpeningDoor);
        }
        CurrentCO_OpeningDoor = CO_OpeningDoor();
        StartCoroutine(CurrentCO_OpeningDoor);
    }
}
