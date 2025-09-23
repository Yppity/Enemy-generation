using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Vector3 _direction;

    private void Update()
    {
        Move();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        transform.forward = _direction;
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
}
