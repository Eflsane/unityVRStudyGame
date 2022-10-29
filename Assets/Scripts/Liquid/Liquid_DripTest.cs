using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid_DripTest : MonoBehaviour
{

    public Material liquidMaterial;
    public GameObject liquidPrefab;
    public GameObject origin;
    public Vector3 speed;
    public float pourThreshold = 45.0f;

    private GameObject currentDrop;
    private int itemIndex;
    [SerializeField]
    private bool isPressed;
    private Material tank;
    private Material cup;
    [SerializeField]
    private float fill;
    [SerializeField]
    private float tanklimit;
    private bool _isPouring = false;
    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        cup = gameObject.GetComponentInParent<Renderer>().material;
        cup.SetFloat("_FillAmount", 0.5f);
        tank = gameObject.GetComponent<Renderer>().material;
        tanklimit = 0.64f;
        fill = 0.5f;
        itemIndex = 0;
        isPressed = false;
    }

    private void Update()
    {
        tank.SetFloat("_FillAmount", fill);

        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if (pourCheck != _isPouring)
        {
            _isPouring = pourCheck;

            if (pourCheck /*&& fill < tanklimit*/) //rests off
            {
                isPressed = true;
                _coroutine = StartCoroutine(StartDriping());
            }
            else
            {
                if(_coroutine != null)
                    StopCoroutine(_coroutine);
                _coroutine = null;
                isPressed = false;
            }
        }
    }

    private void CreateStream()
    {
        itemIndex += 1;
        GameObject newLiquid = Instantiate(
            liquidPrefab,
            origin.transform.position,
            transform.rotation,
            origin.transform
            );
        newLiquid.name = "Liquid" + itemIndex;
        Material newMat = new Material(tank);
        Renderer rd = newLiquid.GetComponent<Renderer>();
        rd.material = newMat;
        StartCoroutine(elongate(newMat));

        newLiquid.GetComponent<DrinkDrip>().drink = 
            new List<DrinkType>(GetComponent<DrinkContainer>().drink);

        currentDrop = newLiquid;
    }

    private IEnumerator StartDriping()
    {
        while(isPressed)
        {
            CreateStream();
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(0.02f); 
    } 

    private IEnumerator elongate(Material mat)
    {
        yield return 0;
        if (isPressed && fill < tanklimit)
        {
            mat.SetFloat("_FillAmount", -1.0f);
            fill += 0.001f;
            StartCoroutine(fillCup());
            StartCoroutine(elongate(mat));
        }
        else
            currentDrop.GetComponent<Rigidbody>().velocity = speed;
    }

    private IEnumerator fillCup()
    {
        yield return new WaitForSeconds(1);
        cup.SetFloat("_FillAmount", cup.GetFloat("_FillAmount") - 0.001f);
    }

    public void pressButton() { if (fill < tanklimit) { CreateStream(); isPressed = true; } }
    public void unpressButton() { isPressed = false; }

    public void emptyCup() { cup.SetFloat("_FillAmount", 0.5f); }

    public void fillTank() { fill = 0.3f; }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    public void SetFillness(float newFillness)
    {
        fill = newFillness;
    }

    public float GetFillness()
    {
        return fill;
    }

    public void SetColors(Color topColor, Color rimColor, Color tint, Color foamLineColor)
    {
        tank.SetColor("_TopColor", topColor);
        tank.SetColor("_RimColor", rimColor);
        tank.SetColor("_Tint", tint);
        tank.SetColor("_FoamColor", foamLineColor);
    }

    public (Color, Color, Color, Color) GetColors()
    {
        return(
            tank.GetColor("_TopColor"),
            tank.GetColor("_RimColor"),
            tank.GetColor("_Tint"),
            tank.GetColor("_FoamColor")
            );
    }
}
