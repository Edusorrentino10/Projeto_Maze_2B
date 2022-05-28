using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    // Referência ao objeto em vazio com os elementos da tela de gameOver como filho
    [SerializeField] GameObject gameOverDisplay;

    // Função de Habilitar a UI
    void EnableUI() => gameOverDisplay.SetActive(true);

    // Utiliza as funções do MonoBehaviour, OnEnable que roda quando o script é habilitado e OnDisable quando é desabilitado
    // No OnEnable subscreve no evento de morte a função EnableUI, para ser executada quando o evento for chamado, e
    // No OnDisable desinscreve a função EnableUI do evento de morte para que não ocorra erro caso a função for chamada e o script
    // não tiver habilitado para executar. 
    private void OnDisable()
    {
        Health.OnDeath -= EnableUI;
    }

    private void OnEnable()
    {
        Health.OnDeath += EnableUI;
    }

}
