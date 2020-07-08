using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de la clase Desactivador que activará el evento cuando el jugador colisione contra una de estas casillas.*/
public class Desactivador4 : MonoBehaviour
{
    //Definición del delegado que formará el evento que se activará en el GamController cuando el jugador choque contra esta casilla.
    public delegate void _OnDesActivate4(GameObject go);
    public static event _OnDesActivate4 OnDesActivate4;

    /*Definición del metodo OnCollisionEnter que activará el evento OnDesactivate cuando el jugador choque con esta casilla.*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (OnDesActivate4 != null)
            {
                OnDesActivate4(gameObject);
            }
        }
    }
}
