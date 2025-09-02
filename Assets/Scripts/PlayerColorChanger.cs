using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    private SpriteRenderer sr;
    public Color color1, color2;
    public bool isColor1;

    [SerializeField] Material colorSwitchingMat;

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

    public void ResetColor()
    {
        colorSwitchingMat.SetColor("_TargetColor", color1);
        isColor1 = true;
    }

    public void ToggleColor()
    {
        
        if (isColor1)
        {
            //sr.color = color2;
            colorSwitchingMat.SetColor("_TargetColor", color2);
            isColor1 = false;
        }
        else
        {
            //sr.color = color1;
            colorSwitchingMat.SetColor("_TargetColor", color1);
            isColor1 = true;
        }
    }
}
