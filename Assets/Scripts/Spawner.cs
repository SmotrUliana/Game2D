using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;
    [SerializeField]
    private float _spawnInterval;
    [SerializeField]
    private float _spawnXRange;
    
    private void Start()
    {
        StartCoroutine(SpawnInInterval());
    }

    private IEnumerator SpawnInInterval()
    {
        while(true)
        {
            int chosenIndex = Random.Range(0, _prefabs.Length);
            GameObject chosenPrefab = _prefabs[chosenIndex];
            float randomizedX = Random.Range(-_spawnXRange, _spawnXRange);
            Vector3 position = new(randomizedX, transform.position.y, transform.position.z);
        
            Instantiate(chosenPrefab, position, quaternion.identity);
            yield return new WaitForSeconds(_spawnInterval); 
        }
    }
}