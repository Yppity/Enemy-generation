using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;
    private Vector3 _direction;

    private void Update()
    {
        Muve();
    }

    private void Muve()
    {
        SetDirection();
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void SetDirection()
    {
        if (transform.position == _waypoints[_currentWaypoint].Position)
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;

        _direction = (_waypoints[_currentWaypoint].Position - transform.position).normalized;
    }
}
