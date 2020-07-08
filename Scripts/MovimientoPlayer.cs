using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de la clase MovimientoPlayer que llevará a cabo el control de un movimiento básico de nuestro jugador.*/
public class MovimientoPlayer : MonoBehaviour
{
    public float mSpeed;
    Vector3 mVelocity;
    void Update()
    {

        mVelocity = Vector3.zero;
        //Indicamos que dependiendo de la tecla que pulsemos nos moveremos en una dirección u otra.
        if (Input.GetKey(KeyCode.W))
        {
            mVelocity.z = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            mVelocity.z = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            mVelocity.x = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            mVelocity.x = -1.0f;
        }
        transform.Translate(mVelocity.normalized * Time.deltaTime * mSpeed); //Llevamos a cabo el Translate con la información que recibimos del teclado.
        //Si pulsamos E o Q rotaremos a nuestro personaje para derecha e izquierda respectivamente.
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, 160.0f * Time.deltaTime, 0.0f);  
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, -160.0f * Time.deltaTime, 0.0f);
        }
    }
}
