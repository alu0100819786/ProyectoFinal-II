using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador5 : MonoBehaviour
{
    /*Clase Activador 5 que contendrá la definición del delegado para la ejecución del evento en GameController, cuando se produzca una colisión
     con el jugador principal.*/
    public delegate void _OnActivate5(GameObject go);
    public static event _OnActivate5 OnActivate5;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//Comprobamos que se colisiona con el Jugador para activar el evento.
        {
            if (OnActivate5 != null)
            {
                OnActivate5(gameObject);
            }
        }
    }
}
