using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public int da�o;
    public float frecuencia;
    private float conteoAtaque;
    private bool preparaAtaque;
    public Detector deteccionAtaque;
    public MovimientoEnemigo movimiento;
    // Start is called before the first frame update
    void Start()
    {
        preparaAtaque = false;
        conteoAtaque = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ataque();
    }

    void Ataque()
    {
        conteoAtaque += Time.deltaTime;
        if (conteoAtaque >= frecuencia)
        {
            preparaAtaque = true;
        }
        if (deteccionAtaque.tocado&&preparaAtaque)
        {
            deteccionAtaque.objetoRegistrado.GetComponent<ValorSalud>().CambioDeVida(-da�o);
            conteoAtaque = 0;
            preparaAtaque = false;
        }
        if (deteccionAtaque.tocado)
        {
            if (movimiento.inteligencia.speed >= 0)
            {
                movimiento.inteligencia.speed -= movimiento.inteligencia.speed;
            }
        }
        else
        {
            movimiento.inteligencia.speed = movimiento.guardarVelocidad;
        }
    }
}
