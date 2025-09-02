using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private makeInvisible platformPhaseState;
    private PlayerScoreCounter scoreCounter;

    public void Awake()
    {
        platformPhaseState = GetComponent<makeInvisible>();
        scoreCounter = FindFirstObjectByType<PlayerScoreCounter>();
    }
    public float speed = 2f;
    public float speedModifier = 1f;
    // Update is called once per frame
    void Update()
    {
        speedModifier = 1 + (scoreCounter.GetScore() / 60f);

        // if the platform is visible, do not move it
        if (platformPhaseState.isOn == true)
        {
            return;
        }
  
        //moves tile left
        transform.Translate(Vector3.left * speed * speedModifier * Time.deltaTime);
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
