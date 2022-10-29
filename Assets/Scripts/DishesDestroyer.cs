using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishesDestroyer : MonoBehaviour
{
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
        if (other.GetComponent<Dishes>() != null)
        {
            Destroy(other.gameObject);
        } 
    }
}
