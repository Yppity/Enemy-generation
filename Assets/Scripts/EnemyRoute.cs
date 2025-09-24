using UnityEngine;

public class EnemyRoute : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private Target _targetPoint;

    public Vector3 SpawnPoint => _spawnPoint.transform.position;
    public Target TargetPoint => _targetPoint;
}
