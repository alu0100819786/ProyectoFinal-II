using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador1 : MonoBehaviour
{
    /*Clase Activador 1 que contendrá la definición del delegado para la ejecución del evento en GameController, cuando se produzca una colisión
     con el jugador principal.*/
    public delegate void _OnActivate1(GameObject go);
    public static event _OnActivate1 OnActivate1;
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//Comprobamos que se colisiona con el Jugador para activar el evento.
        {
            if (OnActivate1 != null)
            {
                OnActivate1(gameObject);
            }
        }
    }
}
