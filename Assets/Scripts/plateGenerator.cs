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

    private ArrayList plates = new ArrayList();
    private int inc = 0;

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
        int x = 0;
        int y = 0;
        x = Random.Range(minX, maxX) + (int)_self.transform.position.x;
        y = Random.Range(minY, maxY);
        float z = -5f;
        clone.transform.position = new Vector3(x, y, z);
        bool trouve = false;
        float tx = clone.transform.position.x +1000;
        float ty = clone.transform.position.y + 1000;
        foreach (GameObject pc in plates)
        {
            float tpx = pc.transform.position.x + 1000;
            float tpy = pc.transform.position.y + 1000;
            if ((tx - tpx) < 4 && (tx - tpx) > -4 && (ty - tpy) < 2 && (ty - tpy) > -2)
            {
                trouve = true;
            }
        }
        if (!trouve)
        {
            plates.Add(clone);
            Debug.Log("destroy");
        }
        else
        {
            clone.SetActive(false);
        }
        inc++;
        return clone;
    }
}
