using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamMy : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private ParticleSystem _splashParticle;
    private LiquidContainer _liquidContainer;

    private Vector3 _targetPosition = Vector3.zero;
    private GameObject _hit;
    private Coroutine _pourRoutine;

    public float pourSpeed = 1.75f;

    public event Action<object, FillingContainer> ContainerCollided = (object sender, FillingContainer collided) => {};
    public event Action<object, FillingContainer> ContainerUnCollided = (object sender, FillingContainer collided) => {};
    public event Action<object> Poured = (object sender) => {};

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _splashParticle = GetComponentInChildren<ParticleSystem>();
        _hit = gameObject;

        _liquidContainer = gameObject.GetComponentInParent<LiquidContainer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveToPos(0, transform.position);
        MoveToPos(1, transform.position);
    }

    private IEnumerator BeginPour()
    {
        while(gameObject.activeSelf && _liquidContainer.GetFillness() >= -1)
        {
            _targetPosition = FindEndPoint();

            MoveToPos(0, transform.position);
            AnimateToPos(1, _targetPosition);

            Poured?.Invoke(this);
            _liquidContainer?.SetFillness(_liquidContainer.GetFillness() - pourSpeed / 100 * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator UpdateParticle()
    {
        while(gameObject.activeSelf)
        {
            //_splashParticle.gameObject.transform.position = _targetPosition;

            bool isHitting = HasReachedPosition(1, _targetPosition);
            //_splashParticle.gameObject.SetActive(isHitting);
            if (isHitting && _hit.GetComponentInChildren<FillingContainer>() != null)
                ContainerCollided?.Invoke(this
                    , _hit.GetComponentInChildren<FillingContainer>());

            yield return null;
        }
    }

    private IEnumerator EndPour()
    {
        while(!HasReachedPosition(0, _targetPosition))
        {
            AnimateToPos(0, _targetPosition);
            AnimateToPos(1, _targetPosition);

            yield return null;
        }

        Destroy(gameObject);
    }

    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 100.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(100.0f);

        if (hit.collider != null)
        {
            bool newColliding = hit.collider.gameObject.GetComponentInChildren<FillingContainer>() != null;
            bool oldColliding = _hit.GetComponentInChildren<FillingContainer>() != null;

            if (newColliding != oldColliding)
            {
                _hit = hit.collider.gameObject;

                if (!newColliding)
                    ContainerUnCollided?.Invoke(this, _hit.GetComponentInChildren<FillingContainer>());
            }
            _hit = hit.collider.gameObject;
        }
        else _hit = gameObject;       

        return endPoint;
    }

    private void MoveToPos(int index, Vector3 targetPos)
    {
        _lineRenderer.SetPosition(index, targetPos);
    }

    private void AnimateToPos(int index, Vector3 targetPos)
    {
        Vector3 currentPos = _lineRenderer.GetPosition(index);
        Vector3 newPos = Vector3.MoveTowards(currentPos, targetPos, Time.deltaTime * pourSpeed);
        _lineRenderer.SetPosition(index, newPos);
    }

    private bool HasReachedPosition(int index, Vector3 targetPos)
    {
        Vector3 currentPos = _lineRenderer.GetPosition(index);
        return currentPos == targetPos;
    } 

    public void Begin()
    {
        StartCoroutine(UpdateParticle());
        _pourRoutine = StartCoroutine(BeginPour());
    }

    public void End()
    {
        StopCoroutine(_pourRoutine);
        _pourRoutine = StartCoroutine(EndPour());
    }

}
