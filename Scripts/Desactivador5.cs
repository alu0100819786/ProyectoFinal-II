using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de la clase Desactivador que activará el evento cuando el jugador colisione contra una de estas casillas.*/
public class Desactivador5 : MonoBehaviour
{
    //Definición del delegado que formará el evento que se activará en el GamController cuando el jugador choque contra esta casilla.
    public delegate void _OnDesActivate5(GameObject go);
    public static event _OnDesActivate5 OnDesActivate5;

    /*Definición del metodo OnCollisionEnter que activará el evento OnDesactivate cuando el jugador choque con esta casilla.*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (OnDesActivate5 != null)
            {
                OnDesActivate5(gameObject);
            }
        }
    }
}
