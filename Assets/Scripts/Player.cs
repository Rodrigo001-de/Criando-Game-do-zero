using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    public float forcaPulo;
    public Rigidbody2D rig;
    public Animator anim; // acessar as animações 

    bool estaPulando;

    // Start is called before the first frame update (Start é chamado antes do primeiro frame do update)
    void Start() // Quando der um play no game o que estiver dentro do Start vai ser chamado quando inicializar o game
    {

    }

    // Update is called once per frame (O Update é chamado a cada frame)
    void Update() // Enquanto o game estiver sendo executado o que estiver dentro do Update vai ser executado
    {
        Movimentar();
        Pular();
    }

    void Movimentar()
    {
        float direcao = Input.GetAxis("Horizontal"); // -1(left) e 1(right)

        rig.velocity = new Vector2(direcao * velocidade, rig.velocity.y); // Vector2 = Vetor(eixo X e eixo Y) de 2 direções(2D) || Vector3 = Vetor(eixo X, eixo Y e Z(Profundidade)) de 3 direções(3D)  

        if (direcao > 0f)
        {
            transform.eulerAngles = new Vector2(0f, 0f);

            if (estaPulando == false)
            {
                anim.SetInteger("transition", 1);
            }
        }

        if (direcao < 0f)
        {
            transform.eulerAngles = new Vector2(0f, 180f);

            if (estaPulando == false)
            {
                anim.SetInteger("transition", 1);
            }
        }

        if (direcao == 0)
        {
            if (estaPulando == false)
            {
                anim.SetInteger("transition", 0);
            }
        }
    }

    void Pular()
    {
        // para pular é preciso precionar o botão Jump(espaço) &&(E) se o estaPulando está false(está no chão)
        if (Input.GetButtonDown("Jump") && !estaPulando)
        {
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse); // Adiciona uma força ao objeto em alguma direção 
            estaPulando = true;
            anim.SetInteger("transition", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecta quando o personagem bateu em algum outro colisor
    {
        // Se colidir com o chão
        if (collision.gameObject.layer == 8)
        {
            estaPulando = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyBody"))
        {
            // Perder vida
            Debug.Log("perdeu vida");
        }

        if (collision.CompareTag("enemyHead"))
        {
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            Destroy(collision.transform.parent.gameObject); // destruir o objeto pai
        }
    }
}
