using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drip : MonoBehaviour
{
    Renderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = gameObject.GetComponent<Renderer>();
        _rend.material.SetFloat("_FillAmount", -1.0f);

        StartCoroutine(DestroyAfter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponentInParent<Collider>().isTrigger)
        {
            if (collider.gameObject.tag != "Drip")
            {
                FillingContainer chContainer =
                collider.gameObject.transform.parent
                .GetComponentInChildren<FillingContainer>();
                if (chContainer != null)
                {
                    Liquid_DripTest dripContainer = chContainer.gameObject.GetComponent<Liquid_DripTest>();
                    if (dripContainer.GetFillness() > -1.0f)
                    {
                        dripContainer.SetFillness
                           (
                           dripContainer.GetFillness()
                           - 0.001f
                           );
                        Debug.Log("WaterInCollider: " + dripContainer.GetFillness());
                    }
                    Debug.Log("WaterInOtherCollider: " + dripContainer.GetFillness());
                    //fill container

                    MixColors(dripContainer, 0.05f);
                }

                Destroy(gameObject);
                //Debug.Log("Collided" + collider.gameObject.tag);
            }
        }  
    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }

    private void MixColors(Liquid_DripTest dripContainer, float power)
    {
        (Color topColor, Color rimColor, Color tint, Color foamLineColor) =
                        (_rend.material.GetColor("_TopColor"),
                        _rend.material.GetColor("_RimColor"),
                        _rend.material.GetColor("_Tint"),
                        _rend.material.GetColor("_FoamColor")
                        );

        (Color oldTopColor, Color oldRimColor, Color oldTint, Color oldFoamLineColor) =
            dripContainer.GetColors();

        dripContainer.SetColors(
            Color.Lerp(oldTopColor, topColor, power),
            Color.Lerp(oldRimColor, rimColor, power),
            Color.Lerp(oldTint, tint, power),
            Color.Lerp(oldFoamLineColor, foamLineColor, power)
            );
    }

    private void MixDrinks()
    {

    }
}
