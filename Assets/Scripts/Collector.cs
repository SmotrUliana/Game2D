using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private Restarter _restarter;
    [SerializeField]
    private Audio _audio;
    
    public int Score { get; private set; } = 0;

    public event Action Collected;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Collectable>(out var collectable))
        {
            if(collectable.IsKiller)
            {
                _restarter.Restart();
            }
            else
            {
                Score++;
                Destroy(collectable.gameObject);
                _audio.PlayCoinSound();
                Collected?.Invoke();
            }
        }
    }
}