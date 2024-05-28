using System.Collections;
using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeStep = 0.5f;
    [SerializeField] private int _increaseValue = 1;

    private int _value;
    private bool _isActive = false;

    private Coroutine _currentCoroutine;
    public event Action<int> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ActivateCoroutine();
    }

    private void ActivateCoroutine()
    {
        _isActive = _isActive ? false : true;

        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(IncreaseValue());
    }

    private IEnumerator IncreaseValue()
    {
        while (_isActive)
        {
            yield return new WaitForSeconds(_timeStep);

            _value += _increaseValue;
            Changed?.Invoke(_value);
        }
    }
}
