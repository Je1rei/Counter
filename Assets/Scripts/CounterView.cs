using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _counter.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _counter.Changed -= ChangeValue;
    }

    private void ChangeValue(int value)
    {
        _text.text = value.ToString();
    }
}
