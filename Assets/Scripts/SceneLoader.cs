using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Index da cena atual
    private int currentSceneIndex;

    private void Awake()
    {
        // Pega o index atual pela função GetActiveScene de SceneManager
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    //Função para reiniciar o nivel
    public void RestartLevel() => SceneManager.LoadScene(currentSceneIndex);
}
