using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{

    public GameObject fireBallPreFab;
    public bool isActive = true;
    public GameObject burning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void disableTile()
    {
        isActive = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == burning.name+"(Clone)")
        {
            
            gameObject.GetComponentInParent<GenerateGrid>().DecreaseNumberOfTiles();

            disableTile();
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (!isActive)
        {
            Destroy(gameObject);
        }

    }
}
