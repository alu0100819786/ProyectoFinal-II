using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definició de la clase MovingEntity que llevará a cabo el control del movimiento de nuestros enemigos.*/
public class MovingEntity : MonoBehaviour
{
    //Creamos las variables para la velocidad y la rotación de los zombies.
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;

    /*Definicion del metodo MoveTowards, que irá definiendo posiciones a las que se iran dirigiendo los enemigos y cuando lleguen a una 
     se creará otra posición a la que deberán de moverse a continuación.*/
   protected void MoveTowards (Vector3 direction)
    {
        Quaternion towardsTargetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, towardsTargetRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
