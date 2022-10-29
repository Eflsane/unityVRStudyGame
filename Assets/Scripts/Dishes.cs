using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishes : MonoBehaviour
{
    public event Action<Dishes> OnDestroyed = (Dishes self) => { };
    public event Action<Dishes> OnTakenAway = (Dishes self) => { };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
