using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverDrink : MonoBehaviour
{
    Customer _customer;
    Animator _animator;
    GameObject _collider;
    // Start is called before the first frame update
    void Start()
    {
        _customer = GetComponentInParent<Customer>();
        _animator = _customer.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    { 
        DrinkContainer drinkContainer = collider.transform.parent
            .transform.parent
            .GetComponentInChildren<DrinkContainer>();
        if(drinkContainer != null)
        {
            List<DrinkType> deliveredDrink = drinkContainer.drink;

            bool isOK = DrinksRecepts.instance.CheckWithRecepts(_customer.orderedDrink, deliveredDrink);
            if (isOK)
            {
                _animator.SetBool("IsOrderOK", true);
                _collider = collider.transform.parent
                    .transform.parent.gameObject;
            }
            
        }
        Debug.Log("Order given with " + collider.gameObject.name);  
    }
}
