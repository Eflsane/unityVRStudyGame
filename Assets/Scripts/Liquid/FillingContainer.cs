using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillingContainer : MonoBehaviour
{
    private LiquidContainer _liquidContainer;

    private Coroutine _coroutine;

    private float _fillingSpeed = 0;

    private Color _frontColor;
    private Color _sideColor;

    private void Awake()
    {
        _liquidContainer = gameObject.GetComponent<LiquidContainer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _liquidContainer.SetFillness(0);

        _liquidContainer.SetColor(Color.white, Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FillingCoroutine()
    {
        while(_liquidContainer.GetFillness() <= 1)
        {
            _liquidContainer.SetFillness(_liquidContainer.GetFillness() + _fillingSpeed / 100 * Time.deltaTime);

            

            (Color frontColor, Color sideColor) = _liquidContainer.GetColor();
            
            _liquidContainer.SetColor(Color.Lerp(frontColor, _frontColor, 1),
                Color.Lerp(sideColor, _sideColor, 1));

            yield return null;
        }        
    }

    public void StartFilling(float speed, Color frontColor, Color sideColor)
    {
        _fillingSpeed = speed;

        _frontColor = frontColor;
        _sideColor = sideColor;

        _coroutine = StartCoroutine(FillingCoroutine());
    }

    public void EndFilling()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}
