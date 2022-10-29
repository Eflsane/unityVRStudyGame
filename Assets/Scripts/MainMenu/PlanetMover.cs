using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    private Rigidbody _rb;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = transform.TransformDirection(Vector3.forward) * speed;
        _rb.velocity = new Vector3(moveVector.x, moveVector.y, moveVector.z);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
