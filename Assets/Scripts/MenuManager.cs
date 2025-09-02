using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMvmt;

    TextMesh scoreText;

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
