using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Health : MonoBehaviour
{
    Health healthController;

    // Referência ao objeto de Texto que indica a vida atual
    [SerializeField] TextMeshProUGUI currentHealthText;
    // Referência ao objeto em vazio com os elementos da interface de vida como filho
    [SerializeField] GameObject healthDisplay;
    private void Awake()
    {
        // Busca o script de vida na cena
        healthController = FindObjectOfType<Health>();
    }

    // Função para atualizar o display de vida
    private void UpdateHealthUI() => currentHealthText.text = healthController.currentHealthPoints.ToString();

    // Função para desabilitar a interface de vida
    private void DisableUI() => healthDisplay.SetActive(false);

    // Funciona de uma maneira parecido com UI_GameOver, aqui subscreve no evento de morte a função DisableUI 
    //e no evento de alteração da vida a funão UpdateHealthUI
    private void OnEnable()
    {
        Health.OnDeath += DisableUI;
        Health.OnHealthChange += UpdateHealthUI;
    }

    private void OnDisable()
    {
        Health.OnDeath -= DisableUI;
        Health.OnHealthChange -= UpdateHealthUI;
    }
}
