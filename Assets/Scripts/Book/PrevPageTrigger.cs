using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevPageTrigger : MonoBehaviour
{
    public event Action PrevPageTriggered = () => { };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PrevPageTriggered?.Invoke();
    }
}
