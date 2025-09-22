using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float FullCircleRadians = Mathf.PI * 2f;

    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _repeatRate = 2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_repeatRate);

        while (enabled)
        {
            SpawnEnemy();

            yield return wait;
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.gameObject.SetActive(true);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
        enemy.SetDirection(GetRandomDirection());
    }

    private Vector3 GetRandomDirection()
    {
        float angel = Random.Range(0, FullCircleRadians);
        float x = Mathf.Cos(angel);
        float z = Mathf.Sin(angel);
        
        return new Vector3(x, 0, z).normalized;
    }
}
