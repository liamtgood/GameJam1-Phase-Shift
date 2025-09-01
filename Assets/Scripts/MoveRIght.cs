using UnityEngine;

public class MoveRIght : MonoBehaviour
{
    private makeInvisible platformPhaseState;

    public void Awake()
    {
        platformPhaseState = GetComponent<makeInvisible>();
    }

    public float speed = 2f;
    // Update is called once per frame
    void Update()
    {
        // if the platform is visible, do not move it
        if (platformPhaseState.isOn == true)
        {
            return;
        }

        //moves the object to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //gets camera boundries
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        //when object reaches right camera boundry, then have object reappear on left side of screen
        float leftEdgeOfObject = GetComponent<Renderer>().bounds.min.x;

        if (leftEdgeOfObject > rightEdge)
        {
            transform.position = new Vector3(leftEdge-(GetComponent<Renderer>().bounds.size.x/2), transform.position.y, transform.position.z);
        }

    }
}
