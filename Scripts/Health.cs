using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*Definición de la clase Health usada en los enemigos para contabilizar su vida y los eventos necesarios para llevar el control del daño y 
 la muerte de los enemigos.*/ 
public class Health : MonoBehaviour
{
    /*Definición de los delegados para los eventos que se activarán al recibir el enemigo daño y al morir.*/
    public delegate void _OnDamaged(GameObject go);
    public static event _OnDamaged OnDamaged;

    public delegate void _OnDeath(GameObject go);
    public static event _OnDeath OnDeath;

    /*Creamos variables para la vida actual de los enemigos, su vida maxima y eventos para el daño recibido y su muerte.*/
    public float currentHealth = 5;
    public float maxHealth = 5;
    public UnityEvent OndamageTaken;
    public UnityEvent OnDead;

    /*Implementamos el código del método DamageTaken, que restará a la salud actual del enemigo el daño recibido e invocará al evento correspondiente
     y si la vida llega a cero, invocará al evento OnDeath para tratar la muerte del enemigo.*/
    void DamageTaken (float amount)
    {
        currentHealth -= amount;
        OndamageTaken.Invoke();

        if (OnDamaged != null)
            OnDamaged(gameObject);

        if (currentHealth <= 0)
        {
            if (OnDeath != null)
                OnDeath(gameObject);

            OnDead.Invoke();

        }
            
        Debug.Log("Vida actual: " + currentHealth);
    }
}
