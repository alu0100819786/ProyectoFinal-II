using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de la clase HealthBar que irá actualizando la información de la barra de vida de los zombies siempre que reciban un disparo.*/
public class HealthBar : MonoBehaviour
{
    Health health;

    void Start()
    {
        health = GetComponentInParent<Health>();
    }
    
    public void UpdateHealth()
    {
        float x = health.currentHealth / health.maxHealth;
        transform.localScale = new Vector3(x, 1, 1);
    }
}
