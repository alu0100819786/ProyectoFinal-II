using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Clase Bullet que controlará el comportammiento de las balas disparadas por el jugador.*/
public class Bullet : MonoBehaviour
{
    /*Se definen las variables para controlar la velocidad de la bala, su tiempo de vuelo y el daño que inflingirán al enemigo
     con el que impacten.*/
    public float speed = 10;
    public float flyTime = 3f;
    public float damage = 2f;

    public GameObject efecto; //Se define el GameObject que llevará a cabo la creació del efecto de particulas cuando se produsca un impacto.

    Rigidbody rb;

    /*Usamos el Awake para darle color a la bala desde que se crea y para acceder a su rigidbody y darle movimiento fisico. Además llamamos a DestroyBullet
     en el momento en el que se llega al tiempo máximo de vida de la bala.*/
    void Awake()
    {
        GetComponent<Renderer>().material.color = new Color32(255, 87, 51, 0);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        Invoke("DestroyBullet", flyTime);
    }
    /*Metodo DestroyBullet que destruye el gameObject de la bala creado.*/
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    /*Metodo OnTriggerEnter que se activará al entrar en contacto con un enemigo, creando un efecto de particulas para reflejar la sangre en el objetivo,
     además se destruirá la bala y se llamará al metodo DamageTaken de Zombie, que restará el daño de la bala a la vida actual del enemigo.*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Instantiate(efecto, transform.position, transform.rotation);
            DestroyBullet();
            other.SendMessage("DamageTaken", damage);
        }
    }
}
