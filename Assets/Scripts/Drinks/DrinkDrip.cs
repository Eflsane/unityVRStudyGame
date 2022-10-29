using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkDrip : MonoBehaviour
{
    [SerializeField]
    public List<DrinkType> drink;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponentInParent<Collider>().isTrigger)
        {
            if (collider.gameObject.tag != "Drip")
            {
                FillingContainer chContainer =
                collider.gameObject.transform.parent
                .GetComponentInChildren<FillingContainer>();
                if (chContainer != null)
                {
                    DrinkContainer drinkContainer = chContainer.gameObject.GetComponent<DrinkContainer>();
                    
                    foreach(DrinkType item in drink)
                    {
                        if (drinkContainer.drink.Find((x) => x == item) == DrinkType.Null)
                            drinkContainer.drink.Add(item);
                    }
                    //fill container with drink

                }
            }
        }
    }
}
