using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de la clase Gun que llevará cabo el control del arma que usará el jugador.*/
public class Gun : MonoBehaviour
{
    /*Definición del prefab que utilizaremos para las balas, del tiempo de cooldeown que tendremos entre cada disparo y una varibale auxiliar
     par poder contabilizar el tiempo hasta poder disparar otra vez.*/
    public GameObject bulletPrefab;
    public float shotCooldown = 0.25f;
    float lastShotTime = 0;

    /*Definición del método Shoot que comprobará que el tiempo desde el ultimo disparo es superior al tiempo de cooldown y en caso afirmativo
     creará una bala dirigida hacia donde está mirando el arma (y el jugador) y reseteará la auxiliar para repetir el proceso siempre que se llame al método.*/
    public void Shoot()
    {
        if (Time.time - lastShotTime > shotCooldown)
        {
            GameObject.Instantiate(bulletPrefab,transform.position, transform.rotation);
            lastShotTime = Time.time;
        }
    }
}
