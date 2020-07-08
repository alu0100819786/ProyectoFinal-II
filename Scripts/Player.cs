using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Definición de nuestra clase Player que albergará unicamente la llamada al método Shoot cuando se pulse la barra espaciadora del teclado.*/
public class Player : MovingEntity
{
    Gun gun;

    

    void Start()
    {
        gun = GetComponentInChildren<Gun>();
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
            if(gun != null)
                gun.Shoot();
        
    }
}
