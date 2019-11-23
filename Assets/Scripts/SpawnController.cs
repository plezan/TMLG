using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public int nbPlayer = 2;
    public GameObject playerPrefab;
    public Transform Spawn1;
    public Transform Spawn2;

    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players[0] = Instantiate(playerPrefab, Spawn1);
        players[1] = Instantiate(playerPrefab, Spawn2);
        PlayerController playerController1 = players[0].GetComponent<PlayerController>();
        PlayerController playerController2 = players[1].GetComponent<PlayerController>();
        playerController1.HorizontalAxis = "p1_Horizontal";
        playerController1.VerticalAxis = "p1_Vertical";
        playerController2.HorizontalAxis = "p2_Horizontal";
        playerController2.VerticalAxis = "p2_Vertical";
    }
}
