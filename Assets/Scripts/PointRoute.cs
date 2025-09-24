using UnityEngine;

public class PointRoute : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private TargetPoint _targetPoint;

    public Vector3 SpawnPoint => _spawnPoint.transform.position;
    public Vector3 TargetPoint => _targetPoint.transform.position;
}
