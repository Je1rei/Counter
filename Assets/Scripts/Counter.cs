using System.Collections;
using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeStep = 0.5f;
    [SerializeField] private int _increaseValue = 1;

    private int _value;

    private Coroutine _currentCoroutine;

    public event Action<int> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ActivateCoroutine();
    }

    private void ActivateCoroutine()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
        else
        {
            _currentCoroutine = StartCoroutine(IncreaseValue());
        }
    }

    private IEnumerator IncreaseValue()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeStep);

        while (enabled)
        {
            yield return wait;

            _value += _increaseValue;
            Changed?.Invoke(_value);
        }
    }
}
