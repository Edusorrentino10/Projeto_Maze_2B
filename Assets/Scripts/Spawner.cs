using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Referência ao objeto para spawnar
    [SerializeField] GameObject objectToSpawn;

    // variavel do tipo WaitForSeconds para evitar ficar criando toda hora uma temporária
    WaitForSeconds waitTime = new WaitForSeconds(4f);

    // Referência a courotine atual
    IEnumerator currentSpawnerTimer;

    void Start()
    {
        // Confere se já tem uma courotine de Spawner rodando,
        // Se tiver, para a atual e inicia uma nova
        if (currentSpawnerTimer != null)
        {
            StopCoroutine(currentSpawnerTimer);
        }
        currentSpawnerTimer = CO_SpawnerTimer();
        StartCoroutine(currentSpawnerTimer);
    }

    // Courotine com um while infinito para ficar spawnando objetos entre um certo intervalo de tempo
    IEnumerator CO_SpawnerTimer()
    {
        while (true)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            yield return waitTime;
        }
    }
}
