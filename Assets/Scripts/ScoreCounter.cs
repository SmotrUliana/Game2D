using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Collector _collector;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _collector.Collected += UpdateScore;
    }

    private void UpdateScore() =>
        _text.text = $"Score: {_collector.Score}";
}