using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public int nbPlayer = 2;
    public GameObject playerPrefab;
    public Transform[] spawns;

    GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = new GameObject[nbPlayer];

        for (int i = 0; i < players.Length; i++)
        {
            players[i] = Instantiate(playerPrefab, spawns[i]);
            PlayerController pc = players[i].GetComponent<PlayerController>();
            pc.HorizontalAxis = "p"+(i+1)+"_Horizontal";
            pc.VerticalAxis = "p"+(i+1)+"_Vertical";

            Weapon wp = players[i].GetComponent<Weapon>();
            wp.fireKey = "p" + (i + 1) + "_Action1";
            wp.waterKey = "p" + (i + 1) + "_Action2";
            wp.fireShoot = players[i].transform.GetChild(0).gameObject.transform;
            wp.waterShoot = players[i].transform.GetChild(1).gameObject.transform;
        }
    }
}
