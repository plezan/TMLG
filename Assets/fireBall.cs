using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float charge;
    public float time = 0;
    // Start is called before the first frame update
    public void SetTime (float charging)
    {
        this.charge = charging;
    }
    void Start()
    {
        rb.velocity = transform.right * speed;
        time += Time.deltaTime;
    }
    void Update()
    {
        if(time > charge*3)
        {
            Destroy(gameObject);
            time = 0;
        }
        time += Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //WallScript Collision = collision.GetComponent<WallScript>();
        Destroy(gameObject);
    }
}
