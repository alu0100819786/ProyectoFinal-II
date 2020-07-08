using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*Definición de la clase Player Health que llevará el control de las llamadas a los eventos correspondientes a cuando
 el jugador reciba daño o su vida llegue a cero y muera.*/
public class PlayerHealth : MonoBehaviour
{
    //Definición de los delegados de los eventos para contabilizar el daño recibido y cuando sea necesario, la muerte del personaje.
    public delegate void _OnPlayerDamaged(GameObject go);
    public static event _OnPlayerDamaged OnPlayerDamaged;

    public delegate void _OnPlayerDeath(GameObject go);
    public static event _OnPlayerDeath OnPlayerDeath;

    public float currentPlayerHealth = 10;
    public float maxPlayerHealth = 10;

    /*Definicion del metodo OnCollisionEnter que contabilizará si chocamos con un enemigo y dependiendo de la vida que tengamos se activará
     el evento OnPlayerDamaged o el evento OnPlayerDeath.*/
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            currentPlayerHealth -= 1;

            if(currentPlayerHealth > 0)
            {
                if (OnPlayerDamaged != null)
                    OnPlayerDamaged(gameObject);
            }

            if(currentPlayerHealth == 0)
            {
                if (OnPlayerDeath != null)
                    OnPlayerDeath(gameObject);

                currentPlayerHealth = 10;
            }
        }
    }
}
