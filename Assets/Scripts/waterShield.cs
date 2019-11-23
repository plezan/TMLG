using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterShield : MonoBehaviour
{
    public float speed;
    public float charge;
    public float time = 0;
    public GameObject burnedPrefab;
    public GameObject burningPrefab;


    // Start is called before the first frame update
    void Start()
    {
        time += Time.deltaTime;
    }


    void Update()
    {

        Debug.Log("dazzefzezf");
        if (time > 1)
        {
            Destroy(gameObject);
            time = 0;
        }
        time += Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == burningPrefab.name + "(Clone)")
        {
            var obj = Instantiate(burnedPrefab, new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z), Quaternion.identity);
            obj.transform.localScale = new Vector3(collision.transform.localScale.x, collision.transform.localScale.y, collision.transform.localScale.z);
            Destroy(collision.gameObject);

        }
    }
}
