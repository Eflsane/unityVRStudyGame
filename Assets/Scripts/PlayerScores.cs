using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    public static PlayerScores instance;

    public float fame = 0.0f;
    public float money = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        money = 0.0f;
        fame = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
