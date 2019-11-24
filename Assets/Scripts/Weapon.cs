using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fireShoot;
    public GameObject fireBallPrefab;
    public Transform waterShoot;
    public GameObject waterShielPrefab;
    public float charge = 0;
    public bool chargingBall= false;
    public string fireKey;
    public string waterKey;

    private bool watering = false;
    private float waterCharge = 0;

    void Shoot(float Charging)
    {
        fireShoot.SetPositionAndRotation(new Vector3(fireShoot.position.x, fireShoot.position.y, -10), fireShoot.rotation);
   
        var fireball = Instantiate(fireBallPrefab, fireShoot.position, fireShoot.rotation);
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
        if (watering)
        {
            waterCharge += Time.deltaTime;
        }
        if (Input.GetButtonDown(fireKey))
        {
            charge += Time.deltaTime;
            chargingBall = true;
            fireShoot.parent.GetComponent<Animator>().SetBool("isHolding", true);
        }
        if (Input.GetButtonUp(fireKey))
        {
            chargingBall = false;
            Shoot(charge);
            charge = 0;
            fireShoot.parent.GetComponent<Animator>().SetBool("isHolding", false);
        }
        if (Input.GetButtonDown(waterKey) && !watering)
        {
            Shield();
            waterShoot.parent.GetComponent<Animator>().SetBool("isWatering", true);
            watering = true;
        }
        if (waterCharge >= 2)
        {
            waterShoot.parent.GetComponent<Animator>().SetBool("isWatering", false);
            waterCharge = 0;
            watering = false;
        }
    }
}
