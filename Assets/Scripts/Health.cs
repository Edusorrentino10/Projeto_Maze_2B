using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    // Evento para ser chamado quando o personagem morrer
    public static event Action OnDeath;

    // Evento para ser chamado quando o personagem sofrer alterações na vida
    public static event Action OnHealthChange;

    public int currentHealthPoints { private set; get; }
    private int maxHealthPoints = 1;
    private bool invencible = false;

    //
    IEnumerator currentInvencibleTimer;
    [SerializeField] float InvincibilityTime = 0.5f;
    WaitForSeconds waitInvincibilityTime;

    void Start()
    {
        // Pega a vida maxima e adiciona na atual quando o script for iniciado
        currentHealthPoints = maxHealthPoints;
        // Chama o evento de alteração de vida
        OnHealthChange?.Invoke();
        // Define o tempo de espera de invencibilidade entre um hit e outro
        waitInvincibilityTime = new WaitForSeconds(InvincibilityTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Quando colidir com um objeto com a tag "Danger" ele vai remover 1 de hp caso não esteja invencivel
        if (other.gameObject.tag == "Danger")
        {
            if (invencible) return;
            if (currentHealthPoints >= 0)
            {
                currentHealthPoints--;
                OnHealthChange?.Invoke();

                if (currentHealthPoints <= 0)
                {
                    OnDeath?.Invoke();
                }
                else
                {
                    // Inicia a invencibilidade temporaria quando leva um hit para que não tome varios danos de um vez
                    StartInvencibleTimer();
                }
            }
        }
    }

    // uma courotine pra tirar a invencibilidade quando acabar o tempo definido
    IEnumerator CO_InvecibleTimer()
    {
        yield return waitInvincibilityTime;
        invencible = false;
    }

    void StartInvencibleTimer()
    {
        // Define como invencivel, confere se já tem uma courotine de invencibilidade rodando,
        // Se tiver, para a atual e inicia uma nova
        invencible = true;
        if (currentInvencibleTimer != null)
        {
            StopCoroutine(currentInvencibleTimer);
        }
        currentInvencibleTimer = CO_InvecibleTimer();
        StartCoroutine(currentInvencibleTimer);
    }
}
