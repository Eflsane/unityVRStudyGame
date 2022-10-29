using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiuceBottlePlacer : MonoBehaviour
{
    public event Action<Liquid_DripTest> BottlePlaced = (Liquid_DripTest bootleToJuice) => { };
    public event Action BottleUnPlaced = () => { };

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
        if(other.GetComponentInChildren<Liquid_DripTest>() != null && other.GetComponent<CanGrabMy>())
        {
            BottlePlaced?.Invoke(other.GetComponentInChildren<Liquid_DripTest>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInChildren<Liquid_DripTest>() != null)
        {
            BottleUnPlaced?.Invoke();
        }
    }
}
