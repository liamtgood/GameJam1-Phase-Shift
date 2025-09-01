using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    private SpriteRenderer sr;
    public Color color1, color2;
    public bool isColor1;

    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;
        // if (timer >= 3f)
        // {
        //     ToggleColor();
        //     timer = 0f;
        // }
    }

    public void ToggleColor()
    {
        if (isColor1)
        {
            sr.color = color2;
            isColor1 = false;
        }
        else
        {
            sr.color = color1;
            isColor1 = true;
        }
    }
}
