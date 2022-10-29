using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    private Random _rand;

    public List<Customer> customersPrefabs;

    public List<Customer> customers;
    public List<Transform> customersSeats;
    // Start is called before the first frame update

    private void Awake()
    {
        _rand = new Random();
    }

    void Start()
    {
        for(int i = 0; i < customersSeats.Count; i++)
        {
            StartCoroutine(SpawnCustomer(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnCustomer(int seatNum)
    {
        float seconds = Random.Range(4.0f, 70.0f);
        yield return new WaitForSeconds(seconds);

        int customerTypeNum = Random.Range(0, customersPrefabs.Count);
        Customer customer = Instantiate(
            customersPrefabs[customerTypeNum],
            customersSeats[seatNum].position, customersSeats[seatNum].rotation,
            transform.parent
            );

        customer.transform.SetParent(transform, true);
        customer.transform.position = new Vector3(
            customer.transform.position.x,
            customer.transform.position.y,
            7.8f
            );

        customers[seatNum] = customer;

        customer.seatNum = seatNum;

        customer.OnDestroyed += Customer_OnDestroyed;

        //подписаться на уничтожение
    }

    private void Customer_OnDestroyed(Customer self)
    {
        if (self.isOrderTaken)
            PlayerScores.instance.fame += 10;
        else
            PlayerScores.instance.fame -= 8;

        if(PlayerScores.instance.fame >= -1)
        {
            StartCoroutine(SpawnCustomer(self.seatNum));
            Debug.Log("start spawning customer by num" + self.seatNum);
        }      
    }
}
