using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidContainer : MonoBehaviour
{
    private Renderer _rend;

    public Color liquidColorFront;
    public Color liquidColorSide;

    private void Awake()
    {
        _rend = gameObject.GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetColor(liquidColorFront, liquidColorSide);
    }

    public float GetFillness()
    {
        return _rend.material.GetFloat("Fill");
    }

    public void SetFillness(float fill)
    {
        _rend.material.SetFloat("Fill", fill);
    }

    public void SetColor(Color frontColor, Color sideColor)
    {
        _rend.material.SetColor("FrontColor", frontColor);
        _rend.material.SetColor("SideColor", sideColor);
    }
    public (Color, Color) GetColor()
    {
        Color frontColor =  _rend.material.GetColor("FrontColor");
        Color sideColor = _rend.material.GetColor("SideColor");

        return (frontColor, sideColor);
    }
}
