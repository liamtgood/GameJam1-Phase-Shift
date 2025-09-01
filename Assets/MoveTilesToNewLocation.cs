using UnityEngine;

public class MoveTilesToNewLocation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        //if a tiles Y value is 10 less than the camera y value then
        //move the tiles Y value to +20 the camera value
        int randomX = Random.Range(-6, 6);
        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            transform.position = new Vector3(Camera.main.transform.position.x + randomX, Camera.main.transform.position.y + 30, transform.position.z);
        }
       
    }
}
