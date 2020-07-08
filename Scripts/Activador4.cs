using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador4 : MonoBehaviour
{
    /*Clase Activador 4 que contendrá la definición del delegado para la ejecución del evento en GameController, cuando se produzca una colisión
     con el jugador principal.*/
    public delegate void _OnActivate4(GameObject go);
    public static event _OnActivate4 OnActivate4;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//Comprobamos que se colisiona con el Jugador para activar el evento.
        {
            if (OnActivate4 != null)
            {
                OnActivate4(gameObject);
            }
        }
    }
}
