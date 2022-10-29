using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevPageButton : MonoBehaviour
{
    private Book _book;

    // Start is called before the first frame update
    void Start()
    {
        _book = GetComponentInParent<Book>();

        _book.PrevPageClicked += _book_PrevPageClicked;
    }

    private void _book_PrevPageClicked()
    {
        if (!_book.isClicked)
        {
            _book.isClicked = true;

            _book.pages[_book.CurrPage].SetActive(false);

            if (_book.CurrPage > 0)
                _book.CurrPage--;
            else
                _book.CurrPage = _book.Count - 1;

            _book.pages[_book.CurrPage].SetActive(true);
        }
          
    }

    // Update is called once per frame
    void Update()
    {

    }


}
