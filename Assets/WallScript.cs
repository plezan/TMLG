using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int Health = 3;
    public GameObject destroyEffect;

   public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {

        }
    }

    void Destroy()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
