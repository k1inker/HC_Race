using System.Collections;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPosition;
    [SerializeField] private GameObject[] spawnObject;

    [SerializeField] private float minSpawnRate;
    [SerializeField] private float maxSpawnRate;

    private Transform _parentTransform;
    private void Awake()
    {
        StartCoroutine(SpawnObject());
        _parentTransform = RoadManager.Instance.MoveableRoad.transform;
    }
    private IEnumerator SpawnObject()
    {
        while (true)
        {
            float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(spawnRate);

            Instantiate(spawnObject[GetRandomIndex(spawnObject)],
                spawnPosition[GetRandomIndex(spawnPosition)].position, Quaternion.identity, _parentTransform);
        }
    }
    private int GetRandomIndex<T>(T[] array)
    {
        return Random.Range(0, array.Length);
    }    
}
