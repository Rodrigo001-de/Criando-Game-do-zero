using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rig;
    public float velocidade;
    public float tempoNaDirecao;

    float tempo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime; // Soma o tempo em segundos

        if (tempo >= tempoNaDirecao)
        {
            velocidade = -velocidade;
            tempo = 0f;
        }

        if (velocidade > 0) // direita 
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        if (velocidade < 0) // esquerda
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        rig.velocity = new Vector2(velocidade, rig.velocity.y);
    }
}
