using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de nuestra clase ZombieGenerator que llevará a cabo la generación de enemigos en diferentes spots del mapa.*/
public class ZombieGenerator : MonoBehaviour
{
    //Definimos las variables del tiempo de reaparición de un zombie y el radio de distancia en el que pueden aparecer.
    //Por otra parte tambien creamos el prefab del cual van a instanciar los zombies que generemos.
    public GameObject zombiePrefab;
    public float spawnTime = 1f;
    public float spawnRadius = 1f;

    /*Definición del metodo Awake que comenzará la corrutina cuando se cree el Spawn por primera vez.*/
    void Awake()
    {
        StartCoroutine(Spawner());
    }

    /*Definición del método ActivadoDeNuevo que comenzará la corrutina cuando el spawner sea activado una segunda vez.*/
    void ActivadoDeNuevo()
    {
        StartCoroutine(Spawner());
    }

    /*Definición del método GenerateZombie que creará a nuestros zombies en una posición aleatoria dentro del radio de spawn.*/
    void GenerateZombie()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0.5f;
        GameObject.Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
    }
    
    /*Definición de nuestra corrutina que se ejecutará siempre que el spawner esté activo y creará un zombie cada vez que pase el tiempo de Spawn establecido.*/
    IEnumerator Spawner()
    {
        while (true)
        {
            GenerateZombie();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
