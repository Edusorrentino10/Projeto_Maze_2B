using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    private float rot;
    [SerializeField] private float rotSpeed;
    private float jumpSpeed = 18f;
    private Vector3 moveDirection;
    
    //Essa função atribui os componentes de Controller e Animações às variáveis 
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //Essa função controla o movimento do Player:
    
    // ao apertar espaço fará o Jogador pular e quando o jogador voltar ao chão  (isGrounded) o Vector3 será zerado novamente.
    // para cada "if" inicia ou termina uma animação do personagem
    void Move()
    {
        if(controller.isGrounded)
        {
            // quando o Player tiver no chão, a movimentação padrão será ficar parado, com a animação idle.
            moveDirection = Vector3.zero;
            anim.SetInteger("transition", 0);

            // se apertar W, anda para frente e faz a animação.
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                anim.SetInteger("transition", 1);
            }
            // ao soltar a tecla W, o Player para de andar. 
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }
            // ao apertar ESPAÇO o Player irá pular e fazer a animação de pulo.
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection = Vector3.up * jumpSpeed;   
                anim.SetInteger("transition", 2);
            }

        }

        // controla a rotação horizontal do Player.
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
