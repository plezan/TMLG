using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fireShoot;
    public GameObject fireBallPrefab;
    public Transform waterShoot;
    public GameObject waterShielPrefab;
    public float charge = 0;
    public bool chargingBall= false;
<<<<<<< HEAD
    public string key;

    void Shoot(float Charging)
    {
        fireShoot.SetPositionAndRotation(new Vector3(fireShoot.position.x, fireShoot.position.y, -10), fireShoot.rotation);
        var fireball = Instantiate(fireBallPrefab,fireShoot.position,fireShoot.rotation);
=======
    public string fireKey;
    public string waterKey;

    void Shoot(float Charging)
    {

        var fireball = Instantiate(fireBallPrefab, fireShoot.position, fireShoot.rotation);
>>>>>>> c8bc2d64ec351d38a91f776f87c07980c1b9ffad
        fireball.GetComponent<fireBall>().SetTime(Charging);
    }

    void Shield()
    {
        var obj = Instantiate(waterShielPrefab, waterShoot.position, waterShoot.rotation);
        obj.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(chargingBall)
        {
            charge += Time.deltaTime;
        }
        if(Input.GetButtonDown(fireKey))
        {
            charge += Time.deltaTime;
            chargingBall = true;
        }
        if (Input.GetButtonUp(fireKey))
        {
            chargingBall = false;
            Shoot(charge);
            charge = 0;
        }
        if (Input.GetButtonDown(waterKey))
        {
            Shield();
        }
    }
}
