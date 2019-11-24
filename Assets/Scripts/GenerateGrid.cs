using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    ArrayList tileGrid = new ArrayList();

    public float HEIGHTOFGRID = 10.0f;
    public float WIDTHOFGRID = 20.0f;
    public float HEIGHTOFTILE = 0.4f;
    public float WIDTHOFTILE = 0.4f;
    public GameObject tilePrefab;
    // public GameObject jaugePrefab;
    public GameObject myJauge;

    public float UPLEFTCORNER_X = -8.54f;
    public float UPLEFTCORNER_Y = 4.84f;
    const float UPLEFTCORNER_Z = -5.0f;
    public int pourcentageToWin = 80;

    int nbTotalTile;
    int nbTileActive;
    int nbTotalTile80;

    // Start is called before the first frame update
    void Awake()
    {

        nbTotalTile = 0;

        // GameObject tile = Instantiate(tilePrefab, new Vector3(UPLEFTCORNER_X, UPLEFTCORNER_Y, UPLEFTCORNER_Z), Quaternion.identity);
        ArrayList currentColumn;
        while (!isLineFull(tileGrid))
        {
            float newX = UPLEFTCORNER_X + (tileGrid.Count * HEIGHTOFTILE);

            tileGrid.Add(new ArrayList());


            currentColumn = (ArrayList)tileGrid[tileGrid.Count - 1];
            while (!isColumnFull(currentColumn))
            {

                float newY = UPLEFTCORNER_Y - (currentColumn.Count * WIDTHOFTILE);
                GameObject tile;
                currentColumn.Add( tile = Instantiate(tilePrefab, new Vector3(newX, newY, UPLEFTCORNER_Z), Quaternion.identity));
                nbTotalTile++;
                tile.transform.parent = gameObject.transform;
            }

        }

        bool isLineFull(ArrayList line)
        {
            if (line.Count * WIDTHOFTILE >= WIDTHOFGRID)
            {
                return true;
            }
            return false;
        }

        bool isColumnFull(ArrayList col)
        {
            if (col.Count * HEIGHTOFTILE >= HEIGHTOFGRID)
            {
                return true;
            }
            return false;
        }
        nbTotalTile80=(nbTotalTile * pourcentageToWin) / 100;
        nbTileActive = nbTotalTile80;
        Debug.Log("PourcentageVie " + GetPourcentageVie());


        //myJauge = Instantiate(jaugePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z  - 10), Quaternion.identity);
        //myJauge.transform.SetParent(gameObject.transform);
        myJauge.GetComponent<Animator>().SetInteger("StateJauge", StateTapestry());



    }


    public int GetNumberOfTiles()
    {
        return nbTileActive;
    }

    public int DecreaseNumberOfTiles()
    {
        if (nbTileActive > 0)
        {
            nbTileActive-= 1;
        }
        return nbTileActive;
    }

    public int GetPourcentageVie()
    {
        
        return (int)(((double)nbTileActive / (double)nbTotalTile80) * 100);
    }

    private void Update()
    {

        //Debug.Log("GetPourcentageVie : " + GetPourcentageVie());
        //Debug.Log("Statetapestry " + StateTapestry());
        myJauge.GetComponent<Animator>().SetInteger("StateJauge", StateTapestry());

    }

    public int StateTapestry()
    {
        return ((GetPourcentageVie()) / 10);
    }




}