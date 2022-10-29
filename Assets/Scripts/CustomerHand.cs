using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerHand : MonoBehaviour
{
    Customer _customer;
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _customer = GetComponentInParent<Customer>();
        _animator = _customer.GetComponent<Animator>();
        //_animator = _customer.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        DrinkContainer drinkContainer = collider
            .GetComponentInChildren<DrinkContainer>();
        if (drinkContainer != null && collider.GetComponent<CanGrabMy>() != null)
        {
             List<DrinkType> deliveredDrink = drinkContainer.drink;

            collider.transform.SetParent(transform, true);       
                    //= transform;
            collider
                .GetComponent<Rigidbody>()
                .useGravity = false;
            collider
                .GetComponent<Rigidbody>()
                .isKinematic = true;

            collider.transform.position = transform.position;
            collider.transform.rotation = new Quaternion(0, 0, 0, 0);

            _animator.gameObject.GetComponent<Customer>().isOrderTaken = true;

            Debug.Log("IsOrderTaken  " +
                _animator.gameObject.GetComponent<Customer>().isOrderTaken);
        }

        Debug.Log("Hand Touched with " + collider.gameObject.name);
    }
}
