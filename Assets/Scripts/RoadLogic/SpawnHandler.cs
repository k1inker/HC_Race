using System.Collections;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPosition;
    [SerializeField] private GameObject[] spawnObject;

    [SerializeField] private float minSpawnRate;
    [SerializeField] private float maxSpawnRate;
    [SerializeField] private bool _useParent = true;

    private Transform _parentTransform;
    private void OnEnable()
    {
        PlayerStats.Instance.OnDeath += StopSpawn;
        ManagerUI.Instance.OnStartRace += StartSpawn;
    }
    private void OnDisable()
    {
        PlayerStats.Instance.OnDeath -= StopSpawn;
        ManagerUI.Instance.OnStartRace -= StartSpawn;
    }
    private IEnumerator SpawnObject()
    {
        while (true)
        {
            float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(spawnRate);

            if (_useParent)
            {
                Instantiate(spawnObject[GetRandomIndex(spawnObject)],
                    spawnPosition[GetRandomIndex(spawnPosition)].position, Quaternion.identity, _parentTransform);
            }
            else
                Instantiate(spawnObject[GetRandomIndex(spawnObject)],
                    spawnPosition[GetRandomIndex(spawnPosition)].position, Quaternion.identity);
        }
    }
    private int GetRandomIndex<T>(T[] array)
    {
        return Random.Range(0, array.Length);
    }    
    private void StartSpawn()
    {
        _parentTransform = RoadManager.Instance.MoveableRoad.transform;
        StartCoroutine(SpawnObject());
    }
    private void StopSpawn()
    {
        StopAllCoroutines();
    }
}
