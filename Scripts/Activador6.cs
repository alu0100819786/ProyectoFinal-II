using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador6 : MonoBehaviour
{
    /*Clase Activador 6 que contendrá la definición del delegado para la ejecución del evento en GameController, cuando se produzca una colisión
     con el jugador principal.*/
    public delegate void _OnActivate6(GameObject go);
    public static event _OnActivate6 OnActivate6;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//Comprobamos que se colisiona con el Jugador para activar el evento.
        {
            if (OnActivate6 != null)
            {
                OnActivate6(gameObject);
            }
        }
    }
}
