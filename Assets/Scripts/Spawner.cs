using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyRoute _route;
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
        enemy.gameObject.SetActive(true);
        enemy.transform.position = _route.SpawnPoint;
        enemy.SetTargetPoint(_route.TargetPoint);
    }
}
