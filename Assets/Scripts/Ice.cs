using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
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
        if(other.CompareTag("DripReciever"))
        {
            GameObject iceContainer = other.GetComponentInParent<CanGrabMy>()
                .transform.Find("IceContainer").gameObject;
            transform.SetParent(iceContainer.transform, true);
            transform.position = iceContainer.transform.position;

            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;


            if (!other.GetComponentInParent<CanGrabMy>()
                .GetComponentInChildren<DrinkContainer>().
                drink.
                Contains(GetComponent<DrinkContainer>().drink[0]))
            {
                other.GetComponentInParent<CanGrabMy>()
                .GetComponentInChildren<DrinkContainer>().
                drink.Add(GetComponent<DrinkContainer>().drink[0]);
            }
        }
    }
}
