using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public DrinkType orderedDrink;

    public bool isOrderTaken = false;

    [SerializeField]
    private Image orderImage;

    [SerializeField]
    private TMPro.TextMeshProUGUI orderText;

    [SerializeField]
    private Slider timerSlider;

    [SerializeField]
    private Color timerAlmostOver;

    private ParticleSystem _particleSystem;

    public int seatNum;

    public event Action<Customer> OnDestroyed = (Customer self) => { };


    // Start is called before the first frame update
    void Start()
    {
        int drinkNum = UnityEngine.Random.Range(30, 41);

        //orderedDrink = DrinkType.Vodka;

        orderedDrink = (DrinkType)drinkNum;

        orderText.text = orderedDrink.ToString();
        orderImage.sprite = DrinksRecepts.instance.GetDrinkImage(orderedDrink);

        timerSlider.maxValue = 130.0f;
        timerSlider.value = timerSlider.maxValue;

        _particleSystem = GetComponentInChildren<ParticleSystem>();

        StartCoroutine(TeleportCustomer());
    }

    // Update is called once per frame
    void Update()
    {
        if(timerSlider.value <= 0)
        {
            StartCoroutine(TeleportCustomerBack());
        }
    }

    private IEnumerator TimerTick()
    {
        while(timerSlider.value >= 0)
        {
            yield return new WaitForSeconds(1.0f);

            timerSlider.value = timerSlider.value - 1;

            if (timerSlider.value <= timerSlider.maxValue / 4)
                timerSlider.GetComponentInChildren<Image>().color = timerAlmostOver;
        }     
    } 

    private IEnumerator TeleportCustomer()
    {
        for (int i = 0; i < transform.childCount - 1; i++) //Last one is particle system should be on
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        _particleSystem.Play();

        yield return new WaitForSeconds(3);

        _particleSystem.Stop();

        for (int i = 0; i < transform.childCount - 1; i++) //Last one is particle system should be on
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        StartCoroutine(TimerTick());
    }

    private IEnumerator TeleportCustomerBack()
    {
        _particleSystem.Play();

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }

    public void StopDrinking()
    {
        Debug.Log("Dringking dont stoped");
        if(isOrderTaken)
        {
            StartCoroutine(TeleportCustomerBack());

            Debug.Log("Dringking is stoped");
        }

        GetComponent<Animator>().SetBool("IsOrderOK", false);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
