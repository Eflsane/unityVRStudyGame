using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField]
    private PrevPageTrigger prevPageTrigger;
    [SerializeField]
    private NextPageTrigger nextPageTrigger;
    [SerializeField]
    public List<GameObject> pages;
    [SerializeField]
    private int _currPage;
    [SerializeField]
    private int count;
    public bool isClicked = false;

    public event Action NextPageClicked = () => { };
    public event Action PrevPageClicked = () => { };
    // Start is called before the first frame update
    void Start()
    {
        _currPage = 0;
        pages[_currPage].SetActive(true);

        prevPageTrigger.PrevPageTriggered += PrevPageTrigger_PrevPageTriggered;
        nextPageTrigger.NextPageTriggered += NextPageTrigger_NextPageTriggered;
    }

    private void PrevPageTrigger_PrevPageTriggered()
    {
        PrevPage();
    }

    private void NextPageTrigger_NextPageTriggered()
    {
        NextPage();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            NextPage();
            isClicked = false;
        }
    }

    public int Count
    {
        get => pages.Count;
    }

    public int CurrPage
    {
        get => _currPage;
        set => _currPage = value;
    }

    public void NextPage()
    {
        Debug.Log("PageNextClicked");
        NextPageClicked?.Invoke();
        Debug.Log("PageNextClicked");

        isClicked = false;
    }

    public void PrevPage()
    {
        PrevPageClicked?.Invoke();

        isClicked = false;
    }
}
