using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de nuestra clase Zombie que mediante una maquina de estados llevará a cabo el control de nuestros enemigos y su forma de actuar
 en contra del personaje principal.*/
public class Zombie : MovingEntity
{
    /*Creamos la lista de posibles estados que puede tomar nuestro enemigo.*/
    enum state
    {
        Wander,
        Chase,
        Dead
    }

    state currentState;//Variable auxiliar para conocer el estado actual del enemigo.

    Vector3 targetPosition;
    Vector3 towardsTarget;

    float wanderRadius = 5f;//Distancia a la que el zombie se mantiene vagando por el mapa


    Transform currentTarget;
    float maxChaseDistance = 10f;//Distancia máxima de separación que necesitamos para que un zombie deje de perseguirnos.
    /*Metodo RecalculateTargetPosition que recalculará la posicion a la que nuestro zombie se moverá.*/
    void RecalculateTargetPosition()
    {
        targetPosition = transform.position + Random.insideUnitSphere * wanderRadius;
        targetPosition.y = 0.5f;
    }

    /*Metodo Start en el que cambiaremos el color de los zombies y recalcularemos su posición y comenzaremos al corrutina de la maquina de estados.*/
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
        RecalculateTargetPosition();
        StartCoroutine(FSM());
    }

    /*Mientras el zombie este vivo, conoceremos su estado actual y llevaremos a cabo la corrutina del estado correspondiente.*/
    IEnumerator FSM()
    {
        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    /*Cuando se produzca un cambio de estado en el enemigo lo notificamos y cambiamos el estado actual del zombie por uno nuevo.*/
    void ChangeState(state nextState)
    {
        Debug.Log(currentState + "->" + nextState);
        currentState = nextState;
    }

    /*Estado Wander de nuestro Zombie, mientras el estado de nuestro zombie sea Wander, estará moviendose por el mapa sin destino fijo*/
    IEnumerator Wander()
    {
        while (currentState == state.Wander)
        {

            towardsTarget = targetPosition - transform.position;
            MoveTowards(towardsTarget.normalized);
            if (towardsTarget.magnitude < 0.25f)
                RecalculateTargetPosition();
            Debug.DrawLine(transform.position, targetPosition, Color.green);
            yield return 0;

        }
    }
    /*Estado Chase de nuestro Zombie, una vez entremos dentro del radio de sensor del Zombie, su velocidad se multiplicará por 4,5
     y comenzará a perseguir al jugador hasta alcanzarlo o perderlo de vista si conseguimos alejarnos lo suficiente, por lo que pasaría de nuevo
     a el estado Wander.*/
    IEnumerator Chase()
    {
        movementSpeed *= 4.5f;

        while(currentState == state.Chase)
        {
            towardsTarget = currentTarget.position - transform.position;
            MoveTowards(towardsTarget);

            if (towardsTarget.magnitude > maxChaseDistance)
            {
                ChangeState(state.Wander);
            }   

            Debug.DrawLine(transform.position, currentTarget.position, Color.red);

            yield return 0;
        }

        movementSpeed /= 4.5f;
    }
    /*Si la vida de nuestro enemigo llega a 0 y se produce su muerte, su estado cambia de Wander o Chase a Dead y se llama a la corrutina que llevara a cabo
     la animacion de muerte y desaparición del zombie.*/
    IEnumerator Dead()
    {
        while (currentState == state.Dead)
        {
            yield return StartCoroutine(DeadAnimation());
            Destroy(gameObject);
        }
    }

    /*Implementación del método OnTriggerEnter que contabilizará si el jugador entra en el radio de acecho del zombie por lo que cambiará su estado a Chase
     en caso afirmativo.*/
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            currentTarget = other.transform;
            ChangeState(state.Chase);
        }
    }

    /*Implementación del metodo OnDeadHandler que cambiará el estado de nuestro Zombie a Dead y hará que no se pueda colisionar con el mientras está en la 
     animación de muerte.*/
    public void OnDeadHandler()
    {
        GetComponent<Collider>().enabled = false;
        ChangeState(state.Dead);
    }

    /*Corrutina para generar la animacion de muerte de nuestro Zombie que en un tiempo animationTime, hará que la escala de nuestro zombie se reduzca gradualmente
     hasta desaparecer.*/
    IEnumerator DeadAnimation()
    {
        float animationTime = 0.5f;
        float elapsedTime = 0;

        while(elapsedTime < animationTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return 0;
        }
    }
}
