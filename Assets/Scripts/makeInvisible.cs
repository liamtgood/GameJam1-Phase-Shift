using Unity.VisualScripting;
using UnityEngine;

public class makeInvisible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shiftPhase();
    }

    void shiftPhase()
    {
        if (GetComponent<BoxCollider2D>().enabled == true)
        {
            Color color = GetComponent<Renderer>().material.color;
            color.a = 0.3f;
            GetComponent<Renderer>().material.color = color;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Color color = GetComponent<Renderer>().material.color;
            color.a = 1f;
            GetComponent<Renderer>().material.color = color;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
