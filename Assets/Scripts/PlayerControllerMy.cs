using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMy : MonoBehaviour
{
    private Rigidbody _playerRb;

    public GameObject player;

    public static PlayerControllerMy instance;

    public event Action OnUsePress = () => { };
    public event Action OnRotPress = () => { };
    public event Action OnSquesePress = () => { };
    public event Action OnSqueseUp = () => { };

    public event Action OnStartPress = () => { };
    public event Action OnTwoPress = () => { };

    public float moveMentSpeed = 4;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
    }
    void Start()
    {
        _playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        //Debug.Log(xAxis);
        float zAxis = Input.GetAxis("Vertical");
        //Debug.Log(zAxis);

        Vector3 playerMovement = new Vector3(xAxis, 0, zAxis);

        Vector3 moveVector = player.transform.TransformDirection(playerMovement) * moveMentSpeed;
        _playerRb.velocity = new Vector3(moveVector.x, _playerRb.velocity.y, moveVector.z);

        if(Input.GetKeyDown(KeyCode.E))
        {
            OnUsePress?.Invoke();
        } 
        
        if(Input.GetMouseButton(1))
        {
            OnRotPress?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnSquesePress?.Invoke();
        }

        if(Input.GetMouseButtonUp(0))
        {
            OnSqueseUp?.Invoke();
        }

        if(OVRInput.GetDown(OVRInput.Button.Start) || Input.GetKeyDown(KeyCode.Backspace))
        {
            OnStartPress?.Invoke();
        }

        if(OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.Backslash))
        {
            OnTwoPress?.Invoke();
        }
    }
}
