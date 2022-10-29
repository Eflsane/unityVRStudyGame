using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageTrigger : MonoBehaviour
{
    private Book _book;

    public event Action NextPageTriggered = () => { };
    // Start is called before the first frame update
    void Start()
    {
        _book = GetComponentInParent<Book>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        NextPageTriggered?.Invoke();
    }
}
