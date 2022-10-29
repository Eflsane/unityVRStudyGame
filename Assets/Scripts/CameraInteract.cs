using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteract : MonoBehaviour
{
    GameObject _takenObject;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerMy.instance.OnUsePress += OnUsePress;
        PlayerControllerMy.instance.OnRotPress += OnRotPress;
    }

    // Update is called once per frame
    void Update()
    {
        //ShootRay();
    }

    public void ShootRay()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);

        Physics.Raycast(ray, out hit, 70.0f);

        if (hit.collider != null)
        {
            Debug.Log($"Hitted {hit.collider.gameObject.name}");
            if(hit.collider.GetComponentInParent<CanGrabMy>().GetComponentInChildren<Liquid_DripTest>() != null)
                Crosshair.instance.TurnOn();
        }
        else
            Crosshair.instance.TurnOff();
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject objectToTake = collider.GetComponent<CanGrabMy>().gameObject;
        
            _takenObject = objectToTake;
            
            Crosshair.instance.TurnOn();
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<CanGrabMy>())
        {
            Crosshair.instance.TurnOff();
            _takenObject = null;
        }
    }

    public void OnUsePress()
    {
        Debug.Log("EEEEE9");
        if (_takenObject != null)
        {
            if (transform.childCount <= 0)
            {
                _takenObject.transform.SetParent(transform, true);
                _takenObject.GetComponent<Rigidbody>().useGravity = false;
                _takenObject.GetComponent<Rigidbody>().isKinematic = true;

                Debug.Log(_takenObject.name);
            }
            else
            {
                _takenObject.GetComponent<Rigidbody>().useGravity = true;
                _takenObject.GetComponent<Rigidbody>().isKinematic = false;

                transform.DetachChildren();

                Debug.Log(_takenObject.name);
                _takenObject = null;
            }

        }

        if(transform.childCount > 0)
        {
            
        }
    }

    private void OnRotPress()
    {
        if(transform.childCount > 0)
        {
            float xAxis = Input.GetAxis("Mouse X");
            //Debug.Log(xAxis);
            float yAxis = Input.GetAxis("Mouse Y");
            //Debug.Log(yAxis);

            Quaternion rot = new Quaternion(
                xAxis,
                0,
                yAxis,
                0
                );

            Vector3 s = new Vector3(xAxis, 0, yAxis);
            transform.GetChild(0).transform.Rotate(s * 50);
        }
    }
}
