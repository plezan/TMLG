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

    public float UPLEFTCORNER_X = -8.54f;
    public float UPLEFTCORNER_Y = 4.84f;
    const float UPLEFTCORNER_Z = -5.0f;

    // Start is called before the first frame update
    void Awake()
    {

        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(tilePrefab, new Vector3(UPLEFTCORNER_X, UPLEFTCORNER_Y, UPLEFTCORNER_Z), Quaternion.identity);
        ArrayList currentColumn;
        while (!isLineFull(tileGrid))
        {
            float newX = UPLEFTCORNER_X + (tileGrid.Count * HEIGHTOFTILE);

            tileGrid.Add(new ArrayList());


            currentColumn = (ArrayList)tileGrid[tileGrid.Count - 1];
            while (!isColumnFull(currentColumn))
            {

                float newY = UPLEFTCORNER_Y - (currentColumn.Count * WIDTHOFTILE);

                currentColumn.Add(Instantiate(tilePrefab, new Vector3(newX, newY, UPLEFTCORNER_Z), Quaternion.identity));

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



        // Update is called once per frame
        void Update()
        {

        }
    }
}