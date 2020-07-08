using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Clase Para la casilla de Vida donde el Jugador podrá recuperar salud al colisionar contra ella.*/
public class CasillaVida1 : MonoBehaviour
{
    //Realizamos la definición del delegado que activará el efecto en el GameObject.
    public delegate void _OnGetVida1(GameObject go);
    public static event _OnGetVida1 OnGetVida1;

    GameObject Casilla;

    /*Utilizamos el Awake para acceder a los elementos que forman la casilla y darles el color deseado a cada uno de ellos.*/
     void Awake()
    {
        Casilla = GameObject.FindGameObjectWithTag("CasillaVida1");
        GetComponent<Renderer>().material.color = new Color32(7, 192, 0, 0);
        Casilla.transform.Find("CruzV").gameObject.GetComponent<Renderer>().material.color = new Color32(0, 8, 192, 0);
        Casilla.transform.Find("CruzH").gameObject.GetComponent<Renderer>().material.color = new Color32(0, 8, 192, 0);
        Casilla.transform.Find("CruzH2").gameObject.GetComponent<Renderer>().material.color = new Color32(0, 8, 192, 0);
    }
    /*Definición del metodo OnCollisionEnter que detectará cuando se colisiona con el Jugador y activará el evento en el GameController.*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (OnGetVida1 != null)
            {
                OnGetVida1(gameObject);
            }
        }
    }
}
