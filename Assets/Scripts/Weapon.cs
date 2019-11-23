using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fireShoot;
    public Vector2 fireSpeed;
    public GameObject fireBallPrefab;
    public float charge = 0;
    public bool chargingBall= false;
    public string key;

    void Shoot(float Charging)
    {
        var fireball = Instantiate(fireBallPrefab,fireShoot.position,fireShoot.rotation);
        fireball.GetComponent<fireBall>().SetTime(Charging);
    }
    // Update is called once per frame
    void Update()
    {
        if(chargingBall)
        {
            charge += Time.deltaTime;
        }
        if(Input.GetButtonDown(key))
        {
            charge += Time.deltaTime;
            chargingBall = true;
        }
        if (Input.GetButtonUp(key))
        {
            chargingBall = false;
            Shoot(charge);
            charge = 0;
        }
    }
}
