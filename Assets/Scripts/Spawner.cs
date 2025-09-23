using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    private const float FullCircleRadians = Mathf.PI * 2f;

    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _repeatRate = 2f;

    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(
        createFunc: () => Instantiate(_enemyPrefab),
        actionOnGet: (enemy) => InitializeEnemy(enemy));
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_repeatRate);

        while (enabled)
        {
            _enemyPool.Get();

            yield return wait;
        }
    }

    private void InitializeEnemy(Enemy enemy)
    {
        Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
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
