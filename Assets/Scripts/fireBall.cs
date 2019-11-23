using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float charge;
    public float time = 0;
    public GameObject burningPrefab;


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
        
        if(time > charge*2.5 && collision.name.Contains("Tile"))
        {
            if (collision.name == "Tile(Clone)")
            {

                // Debug.Log("vtore collision name " + collision);
                TileTrigger mygrid = collision.GetComponent<TileTrigger>();
                mygrid.disableTile();

                Instantiate(burningPrefab, new Vector3(collision.transform.position.x, collision.transform.position.y, -1), Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
