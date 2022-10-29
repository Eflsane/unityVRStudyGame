using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourController : MonoBehaviour
{
    private bool _isPouring = false;
    private StreamMy _currentStream;

    public float pourThreshold = 45.0f;
    public Transform origin;
    public GameObject streamPrefab;

    public event Action<object, StreamMy> PouringToContainer = (object sender, StreamMy pouringSream) => {};

    // Update is called once per frame
    void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if(pourCheck != _isPouring)
        {
            _isPouring = pourCheck;

            if (pourCheck)
                StartPour();
            else
                EndPour();
        }
    }

    private void StartPour()
    {
        Debug.Log("start");
        _currentStream = CreateStream();
        _currentStream.Begin();

        _currentStream.ContainerCollided += OnContainerCollided;
        _currentStream.ContainerUnCollided += OnContainerUnCollided;
        _currentStream.Poured += OnPoured;
    }

    private void EndPour()
    {
        Debug.Log("End");
        _currentStream.End();

        _currentStream.ContainerCollided -= OnContainerCollided;
        _currentStream.ContainerUnCollided -= OnContainerUnCollided;
        _currentStream.Poured -= OnPoured;

        _currentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    private StreamMy CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<StreamMy>();
    }

    private void OnContainerCollided(object sender, FillingContainer collided)
    {
        StreamMy s = sender as StreamMy;

        LiquidContainer liquidContainer = gameObject.GetComponent<LiquidContainer>();
        (Color frontColor, Color sideColor) = liquidContainer.GetColor();
        collided.StartFilling(s.pourSpeed, frontColor, sideColor);
    }

    private void OnContainerUnCollided(object sender, FillingContainer collided)
    {
        collided.EndFilling();
    }

    private void OnPoured(object sender)
    {
        StreamMy s = sender as StreamMy;
    }
}
