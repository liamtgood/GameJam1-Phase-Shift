using UnityEngine;

public class MoveTilesToNewLocation : MonoBehaviour
{
    public GameObject tilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        //if a tiles Y value is 10 less than the camera y value then
        //move the tiles Y value to +20 the camera value
        int randomX = Random.Range(-6, 6);
        int numberOfTiles = Random.Range(2, 5);
        if (transform.position.y < Camera.main.transform.position.y - 10)
        {

            for (int i = 0; i < numberOfTiles; i++)
            {
                Instantiate(tilePrefab, new Vector3(randomX + i * 5, Camera.main.transform.position.y + 20, transform.position.z), Quaternion.identity);
            }
            Destroy(gameObject);
        }

       
    }
}
