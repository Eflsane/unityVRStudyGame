using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid_Drip : MonoBehaviour
{

    public Material liquidMaterial;
    public GameObject liquidPrefab;
    public Vector3 speed;
    public float pourThreshold = 45.0f;

    private GameObject currentDrop;
    private int itemIndex;
    [SerializeField]
    private bool isPressed;
    private Material tank;
    private Material cup;
    private float fill;
    private float tanklimit;
    private bool _isPouring = false;

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

            if (pourCheck)
                pressButton();
            else
                unpressButton();
        }
    }

    private void CreateStream() 
    {
        itemIndex += 1;
        GameObject newLiquid = Instantiate(
            liquidPrefab,
            transform.position,
            transform.rotation,
            transform
            );
        newLiquid.name = "Liquid" + itemIndex;
        Material newMat = new Material(liquidMaterial);
        Renderer rd = newLiquid.GetComponent<Renderer>();
        rd.material = newMat;
        StartCoroutine(elongate(newMat));
        currentDrop = newLiquid;
    }

    private IEnumerator elongate(Material mat) 
    {
        yield return 0;
        if (isPressed && fill < tanklimit)
        {
            mat.SetFloat("_FillAmount", mat.GetFloat("_FillAmount") - 0.004f);
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

    public void pressButton() { if (fill < tanklimit) { CreateStream(); isPressed = true; }  }
    public void unpressButton() { isPressed = false; }

    public void emptyCup() { cup.SetFloat("_FillAmount", 0.5f); }

    public void fillTank() { fill = 0.3f; }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }
}
