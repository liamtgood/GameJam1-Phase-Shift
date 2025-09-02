using UnityEngine;

public class MoveTilesToNewLocation : MonoBehaviour
{
    public GameObject tilePrefab;
    private makeInvisible platformPhaseState;

    public void Awake()
    {
        platformPhaseState = GetComponent<makeInvisible>();
    }

    void Update()
    {
        //if a tiles Y value is 10 less than the camera y value then
        //move the tiles Y value to +20 the camera value
        int randomX = Random.Range(-6, 6);
        int randomTileCountValue = Random.Range(1, 10);
        if (transform.position.y < Camera.main.transform.position.y - 10)
        {   
            // 10% chance to not spawn any tiles
            if (randomTileCountValue == 1)
            {
                return;
            } 
            // 10% chance to spawn an extra tile 
            else if (randomTileCountValue == 10)
            {
                SpawnNewTile(randomX);
            }

            // Spawn at least one tile, otherwise
            SpawnNewTile(randomX);

            Destroy(gameObject);
        }

       
    }

    public void SpawnNewTile(int randomX)
    {
        GameObject newTile = Instantiate(tilePrefab, new Vector3(randomX * 5, Camera.main.transform.position.y + 20, transform.position.z), Quaternion.identity);
        makeInvisible newTilePhaseState = newTile.GetComponent<makeInvisible>();
        if (platformPhaseState.isOn)
        {
            newTilePhaseState.TurnOn();
        } else {
            newTilePhaseState.TurnOff();
        }
    }
}
