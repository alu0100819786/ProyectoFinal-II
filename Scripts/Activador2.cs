using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador2 : MonoBehaviour
{
    /*Clase Activador 2 que contendrá la definición del delegado para la ejecución del evento en GameController, cuando se produzca una colisión
     con el jugador principal.*/
    public delegate void _OnActivate2(GameObject go);
    public static event _OnActivate2 OnActivate2;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//Comprobamos que se colisiona con el Jugador para activar el evento.
        {
            if (OnActivate2 != null)
            {
                OnActivate2(gameObject);
            }
        }
    }
}
