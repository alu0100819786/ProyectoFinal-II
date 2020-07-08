using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador3 : MonoBehaviour
{
    /*Clase Activador 3 que contendrá la definición del delegado para la ejecución del evento en GameController, cuando se produzca una colisión
     con el jugador principal.*/
    public delegate void _OnActivate3(GameObject go);
    public static event _OnActivate3 OnActivate3;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//Comprobamos que se colisiona con el Jugador para activar el evento.
        {
            if (OnActivate3 != null)
            {
                OnActivate3(gameObject);
            }
        }
    }
}
