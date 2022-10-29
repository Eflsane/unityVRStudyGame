using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    Image _image;

    public static Crosshair instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        _image.color = Color.green;
    }

    public void TurnOff()
    {
        _image.color = Color.white;
    }
}
