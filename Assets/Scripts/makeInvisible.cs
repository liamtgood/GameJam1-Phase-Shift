using Unity.VisualScripting;
using UnityEngine;

public class makeInvisible : MonoBehaviour
{
    public bool isOn;

    public void Awake()
    {
        if (this.gameObject.tag == "GroupAPlatforms")
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void OnEnable()
    {
        PlayerMovement.playerJumped += shiftPhase;
    }

    public void OnDisable()
    {
        PlayerMovement.playerJumped -= shiftPhase;
    }

    void shiftPhase()
    {
        if (isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a = 1f;
        GetComponent<Renderer>().material.color = color;
        GetComponent<BoxCollider2D>().enabled = true;
        isOn = true;
    }

    public void TurnOff()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a = 0.3f;
        GetComponent<Renderer>().material.color = color;
        GetComponent<BoxCollider2D>().enabled = false;
        isOn = false;
    }
}
