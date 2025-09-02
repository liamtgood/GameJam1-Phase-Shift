using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMvmt;

    public TextMeshProUGUI scoreText; 
    public PlayerScoreCounter scoreCounter;

    public void Update()
    {
        scoreText.text = scoreCounter.GetScore().ToString();
    }

    // enable/disable player movement when this is called
    public void setPlayerCanMove(bool canMove)
    {
        playerMvmt.enabled = canMove;
    }

    public void quitGame()
    {
        Debug.Log("You have quit the game");
        Application.Quit();
    }
}
