using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DishesController : MonoBehaviour
{
    [SerializeField]
    private List<Dishes> _bottles;

    // Start is called before the first frame update
    void Start()
    {
        FirstInstance();
    }

    private void FirstInstance()
    {
        foreach (Dishes item in _bottles)
        {
            Dishes instDish =
                Instantiate(item, item.transform.position, item.transform.rotation);

            instDish.OnDestroyed += Item_OnDestroyed;
            instDish.OnTakenAway += Item_OnDestroyed;
        }
    }

    private void Item_OnDestroyed(Dishes self)
    {
        Debug.Log("Destroyed dish " + self.name);

        Dishes dish = 
            _bottles.FirstOrDefault(x => x.name == self.name.Replace("(Clone)", ""));

        Dishes instDish = 
            Instantiate(dish, dish.transform.position, dish.transform.rotation);

        instDish.OnDestroyed += Item_OnDestroyed;
        instDish.OnTakenAway += Item_OnDestroyed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
