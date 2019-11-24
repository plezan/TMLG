using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject SelectedPlayer = other.gameObject;
        Debug.Log(SelectedPlayer.name);
        if (other.name.Contains("Player"))
        {
            float x = SelectedPlayer.transform.position.x;
            float y = 19;
            float z = SelectedPlayer.transform.position.z;
            SelectedPlayer.transform.SetPositionAndRotation(new Vector3(x, y, z), new Quaternion(0,0,0,0));
        }
    }
}
