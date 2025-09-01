using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public float speed = 2f;
    // Update is called once per frame
    void Update()
    {
        //moves tile left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //gets the left and right edges of camera view
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        //checks if the tile is off the screen on the left, if it is it will reappear on the right side
        float rightEdgeOfObject = GetComponent<Renderer>().bounds.max.x;

        if (rightEdgeOfObject < leftEdge)
        {
            transform.position = new Vector3(rightEdge + (GetComponent<Renderer>().bounds.size.x / 2), transform.position.y, transform.position.z);
        }
    }

}
