using UnityEngine;

public class PlayerScoreCounter : MonoBehaviour
{
    public float highestY;
    public int score;
    public int scoreModifier = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y > highestY)
        {
            highestY = transform.position.y;
            score = (int)highestY * scoreModifier;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        highestY = 0;
        score = 0;
    }
}
