using System;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject redTilePrefab;
    public GameObject blueTilePrefab;

    void Start()
    {

        //spawn in a large group of tiles above the player at random x positions between -7 and 7 and 
        // incremented y positions of 2, spawn in 3-4 tiles per row, maybe have a 
        // standalone script for this
        Boolean isBlue = true;
        for (int i = 0; i < 10; i++)
        {
            
            //checks if the tile was blue, if it was make the next tile red
            if (isBlue == true)
            {
                //spawns in a random number of tiles each row
                int numberOfTiles = UnityEngine.Random.Range(2, 5);
                int randomX = UnityEngine.Random.Range(-6, 6);
                //spawns in the tiles
                for (int j = 0; j < numberOfTiles; j++)
                {
                    Instantiate(blueTilePrefab, new Vector3(randomX + j * 5, 3 * i + 1, 0), Quaternion.identity);
                }
            }
            else
            {
                //spawns in a random number of tiles each row
                int numberOfTiles = UnityEngine.Random.Range(2, 5);
                int randomX = UnityEngine.Random.Range(-6, 6);
                //spawns in the tiles
                for (int j = 0; j < numberOfTiles; j++)
                {
                    Instantiate(redTilePrefab, new Vector3(randomX + j * 5, 3 * i + 1, 0), Quaternion.identity);
                }

            }
            isBlue = !isBlue;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
