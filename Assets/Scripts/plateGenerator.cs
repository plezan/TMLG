using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateGenerator : MonoBehaviour
{
    public GameObject _self;
    public GameObject plateSample;
    public string plateName;
    public int minX;
    public int maxX;
    public int minY;
    public int maxY;
    public int plateCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < plateCount; i++)
        {
            clone();
        }
    }
    GameObject clone()
    {
        var clone = Instantiate(plateSample);
        clone.transform.SetParent(_self.transform);
        clone.name = plateName;
        int x = Random.Range(minX, maxX) + (int) _self.transform.position.x;
        int y = Random.Range(minY, maxY);
        float z = -0.5f;
        clone.transform.position = new Vector3(x, y, z);
        return clone;
    }
}
