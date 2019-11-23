using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{

    public GameObject fireBallPreFab;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.name == fireBallPreFab.name)
        {
            
            print("Triger triggered");

            print(col.name);
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.name == fireBallPreFab.name)
        {

            print("Triger triggered");

            print(col.name);
        }

    }


    // Update is called once per frame
    void Update()
    {
        


    }
}
