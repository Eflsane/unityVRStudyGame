using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonGetter : MonoBehaviour
{
    public event Action<CanSquese> LemonGetted = (CanSquese squesingObject) => { };
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
        if(other.GetComponent<CanSquese>() != null)
        {
            LemonGetted?.Invoke(other.GetComponent<CanSquese>());
        }
    }
}
