using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuringGrowth : MonoBehaviour
{
    public float time = 0;
    public string tileName = "Tile(Clone)";
    private bool isBurning = true;

    // Start is called before the first frame update
    void Start()
    {
        time += Time.deltaTime;
    }

    // Update => Augmente la taille de la brulure
    void Update()
    {
        if (isBurning)
        {
            time += Time.deltaTime;
            gameObject.transform.localScale += new Vector3(0.001f * time / 10, 0.001f * time / 10, 0);
            Collider2D col = gameObject.GetComponent<Collider2D>();
        } 

    }

    // Supprime 1 HP
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == tileName)
        {
            TileTrigger mygrid = collision.GetComponent<TileTrigger>();
            mygrid.disableTile();
        }
    }

    /*
    public void PutOutOFBurning()
    {
        isBurning = false;
        gameObject.GetComponent<BoxCollider2D>()
    }
    */


}
