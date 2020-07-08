using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/*Implementación de nuestra clase GameController que llevará a cabo la gestión de la mayoria de eventos de nuestra aplicación.*/
public class GameController : MonoBehaviour
{
    //Accedemos a los GameObject de las balas, los zombies, los spawners, las casillas de vida y los activadores y desactivadores de los spawners
    //para poder trabajar con ellos.
    GameObject[] Bala;
    GameObject[] Zombie;
    GameObject ZombieSpawner;
    GameObject CasillasDeVida;
    GameObject Activadores;
    GameObject Desactivadores;

    public static GameController controlador;
    /*Creamos las variables auxiliar para guardar y trabajar con las puntuaciones, con la vida del personaje y con la cantidad de activaciones
     que lleva cada spawner*/
    public int scoreActual = 0;
    public int scoreMax = 0;
    public int playerCurrentHealth = 10;
    public int c1, c2, c3, c4, c5, c6 = 0;

    /*Implementación del método Awake donde creamos el controlador*/
    private void Awake()
    {
        if(controlador == null)
        {
            controlador = this;
            DontDestroyOnLoad(this);
        }
        else if(controlador != this)
        {
            Destroy(gameObject);
        }
    }
    /*Implementación del método Start donde accedemos a los gameObjects donde se encuentras los activadores y desactivadores, las casillas de vida y los spawners.*/
    void Start()
    {
        ZombieSpawner = GameObject.FindGameObjectWithTag("ZombieSpawns");
        CasillasDeVida = GameObject.FindGameObjectWithTag("CasillasDeVida");
        Activadores = GameObject.FindGameObjectWithTag("Activadores");
        Desactivadores = GameObject.FindGameObjectWithTag("Desactivadores");
    }

    /*Implementación del método OnEnable donde nos suscribiremos a todos los eventos que vayamos a manejar en este script.*/
    void OnEnable()
    {  
        Health.OnDamaged += HandleOnDamaged;
        Health.OnDeath += HandleOnDeath;

        PlayerHealth.OnPlayerDamaged += HandleOnPlayerDamaged;
        PlayerHealth.OnPlayerDeath += HandleOnPlayerDeath;

        Activador1.OnActivate1 += HandleOnActivate1;
        Desactivador1.OnDesActivate1 += HandleOnDesActivate1;

        Activador2.OnActivate2 += HandleOnActivate2;
        Desactivador2.OnDesActivate2 += HandleOnDesActivate2;

        Activador3.OnActivate3 += HandleOnActivate3;
        Desactivador3.OnDesActivate3 += HandleOnDesActivate3;

        Activador4.OnActivate4 += HandleOnActivate4;
        Desactivador4.OnDesActivate4 += HandleOnDesActivate4;

        Activador5.OnActivate5 += HandleOnActivate5;
        Desactivador5.OnDesActivate5 += HandleOnDesActivate5;

        Activador6.OnActivate6 += HandleOnActivate6;
        Desactivador6.OnDesActivate6 += HandleOnDesActivate6;

        CasillaVida1.OnGetVida1 += HandleOnGetVida1;
        CasillaVida2.OnGetVida2 += HandleOnGetVida2;
        CasillaVida3.OnGetVida3 += HandleOnGetVida3;
        CasillaVida4.OnGetVida4 += HandleOnGetVida4;
        CasillaVida5.OnGetVida5 += HandleOnGetVida5;
        CasillaVida6.OnGetVida6 += HandleOnGetVida6;
        CasillaVida7.OnGetVida7 += HandleOnGetVida7;
    }

    /*Definición del metodo OnDisable donde nos desuscribiremos de todos los eventos a los que estemos suscritos.*/
    void OnDisable()
    {
        Health.OnDamaged -= HandleOnDamaged;
        Health.OnDeath -= HandleOnDeath;

        PlayerHealth.OnPlayerDamaged -= HandleOnPlayerDamaged;
        PlayerHealth.OnPlayerDeath -= HandleOnPlayerDeath;

        Activador1.OnActivate1 -= HandleOnActivate1;
        Desactivador1.OnDesActivate1 -= HandleOnDesActivate1;

        Activador2.OnActivate2 -= HandleOnActivate2;
        Desactivador2.OnDesActivate2 -= HandleOnDesActivate2;

        Activador3.OnActivate3 -= HandleOnActivate3;
        Desactivador3.OnDesActivate3 -= HandleOnDesActivate3;

        Activador4.OnActivate4 -= HandleOnActivate4;
        Desactivador4.OnDesActivate4 -= HandleOnDesActivate4;

        Activador5.OnActivate5 -= HandleOnActivate5;
        Desactivador5.OnDesActivate5 -= HandleOnDesActivate5;

        Activador6.OnActivate6 -= HandleOnActivate6;
        Desactivador6.OnDesActivate6 -= HandleOnDesActivate6;

        CasillaVida1.OnGetVida1 -= HandleOnGetVida1;
        CasillaVida2.OnGetVida2 -= HandleOnGetVida2;
        CasillaVida3.OnGetVida3 -= HandleOnGetVida3;
        CasillaVida4.OnGetVida4 -= HandleOnGetVida4;
        CasillaVida5.OnGetVida5 -= HandleOnGetVida5;
        CasillaVida6.OnGetVida6 -= HandleOnGetVida6;
        CasillaVida7.OnGetVida7 -= HandleOnGetVida7;
    }

    /*Recopilación de metodos HandleOnActivate y HandleOnDesactivate para cada uno de los spawners, estos metodos se activarán al pulsar
     una de las casillas de activación o desactivación respectivamente y funcionan de forma que si pisamos una casilla de activación, activamos el spawner
     correspondiente, su casilla de desactivación correspondiente y desactivamos la casilla de activación que acabamos de pisar. Por otra parte
     también comprobamos si es la primera vez que se activa el spawner o no, para volver a llamar a la corrutina que genera zombies. Por último HandleOnDesactivate
     funciona de forma similar pero inversa, cuando pisamos una de estas casillas, desactivamos la misma, el spawner correspondiente y activamos una casilla de vida
     de estar desactivada y además volvemos a activar la casilla de activación correspondiente.*/
    void HandleOnActivate1(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator1").gameObject.SetActive(true);
        Desactivadores.transform.Find("Desactivador1").gameObject.SetActive(true);
        Activadores.transform.Find("Activador1").gameObject.SetActive(false);
        if (c1 > 0)
        {
            ZombieSpawner.transform.Find("ZombieGenerator1").gameObject.SendMessage("ActivadoDeNuevo");
        }
        c1++;
    }
    void HandleOnDesActivate1(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator1").gameObject.SetActive(false);
        Desactivadores.transform.Find("Desactivador1").gameObject.SetActive(false);
        CasillasDeVida.transform.Find("CasillaVida6").gameObject.SetActive(true);
        Activadores.transform.Find("Activador1").gameObject.SetActive(true);
    }

    void HandleOnActivate2(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator2").gameObject.SetActive(true);
        Desactivadores.transform.Find("Desactivador2").gameObject.SetActive(true);
        Activadores.transform.Find("Activador2").gameObject.SetActive(false);
        if (c2 > 0)
        {
            ZombieSpawner.transform.Find("ZombieGenerator2").gameObject.SendMessage("ActivadoDeNuevo");
        }
        c2++;
    }
    void HandleOnDesActivate2(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator2").gameObject.SetActive(false);
        Desactivadores.transform.Find("Desactivador2").gameObject.SetActive(false);
        CasillasDeVida.transform.Find("CasillaVida5").gameObject.SetActive(true);
        Activadores.transform.Find("Activador2").gameObject.SetActive(true);
    }

    void HandleOnActivate3(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator3").gameObject.SetActive(true);
        Desactivadores.transform.Find("Desactivador3").gameObject.SetActive(true);
        Activadores.transform.Find("Activador3").gameObject.SetActive(false);
        if (c3 > 0)
        {
            ZombieSpawner.transform.Find("ZombieGenerator3").gameObject.SendMessage("ActivadoDeNuevo");
        }
        c3++;
    }
    void HandleOnDesActivate3(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator3").gameObject.SetActive(false);
        Desactivadores.transform.Find("Desactivador3").gameObject.SetActive(false);
        CasillasDeVida.transform.Find("CasillaVida4").gameObject.SetActive(true);
        Activadores.transform.Find("Activador3").gameObject.SetActive(true);
    }

    void HandleOnActivate4(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator4").gameObject.SetActive(true);
        Desactivadores.transform.Find("Desactivador4").gameObject.SetActive(true);
        Activadores.transform.Find("Activador4").gameObject.SetActive(false);
        if (c4 > 0)
        {
            ZombieSpawner.transform.Find("ZombieGenerator4").gameObject.SendMessage("ActivadoDeNuevo");
        }
        c4++;
    }
    void HandleOnDesActivate4(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator4").gameObject.SetActive(false);
        Desactivadores.transform.Find("Desactivador4").gameObject.SetActive(false);
        CasillasDeVida.transform.Find("CasillaVida3").gameObject.SetActive(true);
        Activadores.transform.Find("Activador4").gameObject.SetActive(true);
    }

    void HandleOnActivate5(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator5").gameObject.SetActive(true);
        Desactivadores.transform.Find("Desactivador5").gameObject.SetActive(true);
        Activadores.transform.Find("Activador5").gameObject.SetActive(false);
        if (c5 > 0)
        {
            ZombieSpawner.transform.Find("ZombieGenerator5").gameObject.SendMessage("ActivadoDeNuevo");
        }
        c5++;
    }
    void HandleOnDesActivate5(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator5").gameObject.SetActive(false);
        Desactivadores.transform.Find("Desactivador5").gameObject.SetActive(false);
        CasillasDeVida.transform.Find("CasillaVida2").gameObject.SetActive(true);
        Activadores.transform.Find("Activador5").gameObject.SetActive(true);
    }

    void HandleOnActivate6(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator6").gameObject.SetActive(true);
        Desactivadores.transform.Find("Desactivador6").gameObject.SetActive(true);
        Activadores.transform.Find("Activador6").gameObject.SetActive(false);
        if (c6 > 0)
        {
            ZombieSpawner.transform.Find("ZombieGenerator6").gameObject.SendMessage("ActivadoDeNuevo");
        }
        c6++;
    }
    void HandleOnDesActivate6(GameObject go)
    {
        ZombieSpawner.transform.Find("ZombieGenerator6").gameObject.SetActive(false);
        Desactivadores.transform.Find("Desactivador6").gameObject.SetActive(false);
        CasillasDeVida.transform.Find("CasillaVida1").gameObject.SetActive(true);
        Activadores.transform.Find("Activador6").gameObject.SetActive(true);
    }

    /*Colección de métodos HandleOnGetVida para cada una de las casillas de vida existentes, donde si chocamos con ella y no tenemos la vida entera,
     regenerarán nuestra salud hasta el tope y desactivarán dicha casilla de vida.*/
    void HandleOnGetVida1(GameObject go)
    {
        if(playerCurrentHealth < 10)
        {
            playerCurrentHealth = 10;
            CasillasDeVida.transform.Find("CasillaVida1").gameObject.SetActive(false);
        }
        
    }
    void HandleOnGetVida2(GameObject go)
    {
        if (playerCurrentHealth < 10)
        {
            playerCurrentHealth = 10;
            CasillasDeVida.transform.Find("CasillaVida2").gameObject.SetActive(false);
        }
    }
    void HandleOnGetVida3(GameObject go)
    {
        if (playerCurrentHealth < 10)
        {
            playerCurrentHealth = 10;
            CasillasDeVida.transform.Find("CasillaVida3").gameObject.SetActive(false);
        }
    }
    void HandleOnGetVida4(GameObject go)
    {
        if (playerCurrentHealth < 10)
        {
            playerCurrentHealth = 10;
            CasillasDeVida.transform.Find("CasillaVida4").gameObject.SetActive(false);
        }
    }
    void HandleOnGetVida5(GameObject go)
    {
        if (playerCurrentHealth < 10)
        {
            playerCurrentHealth = 10;
            CasillasDeVida.transform.Find("CasillaVida5").gameObject.SetActive(false);
        }
    }
    void HandleOnGetVida6(GameObject go)
    {
        if (playerCurrentHealth < 10)
        {
            playerCurrentHealth = 10;
            CasillasDeVida.transform.Find("CasillaVida6").gameObject.SetActive(false);
        }
    }
    void HandleOnGetVida7(GameObject go)
    {
        if (playerCurrentHealth < 10)
        {
            playerCurrentHealth = 10;
            CasillasDeVida.transform.Find("CasillaVida7").gameObject.SetActive(false);
        }
    }

    /*Evento HandleOnDamaged que actuará cuando realizemos daño subiendo nuestra puntuación, al igual que el evento siguiente HandleOnDeath
     que sumará puntos en el momento que matemos a un enemigo.*/
    void HandleOnDamaged(GameObject go)
    {
        scoreActual += 100;
    }
    void HandleOnDeath(GameObject go)
    {
        scoreActual += 900;
    }

    /*Evento HandleOnPlayerDamaged que nos restará vida al recibir daño y además nos restará puntuación dejandola a 0, si se fuera a reducir a valores negativos.*/
    void HandleOnPlayerDamaged(GameObject go)
    {
        playerCurrentHealth -= 1;
        scoreActual -= 500;
        
        if(scoreActual < 0)
        {
            scoreActual = 0;
        }
    }
    /*Evento HandleOnPlayerDeath que al igual que el evento anterior nos restará puntuación (impidiendo que no sea negativa) y además como se activará
     al llegar nuestra vida a 0, nos regenerará para poder continuar jugando lo que queramos y guardará nuestro scoreActual en el momento de la muerte
     como máximoScore si es la puntuación mas alta conseguida.*/
    void HandleOnPlayerDeath(GameObject go)
    {
        playerCurrentHealth = 10;
        scoreActual -= 1000;

        if(scoreActual < 0)
        {
            scoreActual = 0;
        }

        if(scoreActual > scoreMax)
        {
            scoreMax = scoreActual;
        }
        
        scoreActual = 0;
    }

    /*Metodo OnGUI que se encargará de crear los Layouts en pantalla para mostrar en todo momento las vidas que tenemos y la puntuación actual y maxima conseguida.*/
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 10, 10), "Score = " + scoreActual);
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(10, 25, 10, 10), "Max = " + scoreMax);
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(10, 500, 10, 10), "Vida = " + playerCurrentHealth);
        GUILayout.EndArea();
    }
}
