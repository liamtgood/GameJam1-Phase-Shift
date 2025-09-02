using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMvmt;

    public TextMeshProUGUI scoreText; 
    public PlayerScoreCounter scoreCounter;

    [Header("Menu UI")]
    [SerializeField] GameObject menuPanel; // Assign your menu panel in the inspector

    private bool menuOpen = true;

    void Update()
    {
        scoreText.text = scoreCounter.GetScore().ToString();

        // Toggle menu with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        menuOpen = !menuOpen;
        menuPanel.SetActive(menuOpen);
        setPlayerCanMove(!menuOpen);
        // Optionally, pause the game when menu is open
        Time.timeScale = menuOpen ? 0f : 1f;
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
