using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageButt : MonoBehaviour
{
    private Book _book;

    // Start is called before the first frame update
    void Start()
    {
        _book = GetComponentInParent<Book>();

        _book.NextPageClicked += _book_NextPageClicked;
        Debug.Log("PageNextStarted");
    }

    private void _book_NextPageClicked()
    {
        if(!_book.isClicked)
        {
            _book.isClicked = true;
            Debug.Log("PageNextClickedIn");

            _book.pages[_book.CurrPage].SetActive(false);

            if (_book.CurrPage < _book.Count - 1)
                _book.CurrPage++;
            else
                _book.CurrPage = 0;

            _book.pages[_book.CurrPage].SetActive(true);

            Debug.Log("PageNextClickedOut");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
