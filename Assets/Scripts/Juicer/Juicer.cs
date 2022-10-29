using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juicer : MonoBehaviour
{
    private CanSquese _squesingObject;
    [SerializeField]
    private Liquid_DripTest _bootleToJuice;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<LemonGetter>().LemonGetted += Juicer_LemonGetted;
        GetComponentInChildren<JiuceBottlePlacer>().BottlePlaced += Juicer_BottlePlaced;
        GetComponentInChildren<JiuceBottlePlacer>().BottleUnPlaced += Juicer_BottleUnPlaced;
    }

    private void Juicer_LemonGetted(CanSquese squesingObject)
    {
        if(_bootleToJuice != null)
        {
            Renderer squeseRender = squesingObject.transform.GetChild(0).GetComponent<Renderer>();
            Renderer bottleLiquidRenderer = _bootleToJuice.GetComponent<Renderer>();

            bottleLiquidRenderer.material = squeseRender.material;
            bottleLiquidRenderer.material.SetFloat("_FillAmount", -0.08f);

            _bootleToJuice.GetComponentInChildren<DrinkContainer>().
            drink = new List<DrinkType>();

            _bootleToJuice.GetComponentInChildren<DrinkContainer>().
            drink.Add(squesingObject.GetComponent<DrinkContainer>().drink[0]);

            Destroy(squesingObject.gameObject);
        }
    }

    private void Juicer_BottlePlaced(Liquid_DripTest bootleToJuice)
    {
        _bootleToJuice = bootleToJuice;
    }

    private void Juicer_BottleUnPlaced()
    {
        _bootleToJuice = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
