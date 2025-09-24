using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] EnemyBody _body;

    private Target _target;
    private Vector3 _direction;

    protected abstract Color Color { get; }

    private void Start()
    {
        SetColor();
    }

    private void Update()
    {
        Move();
    }

    public void SetTargetPoint(Target target)
    {
        _target = target;
        SetDirection();
        transform.forward = _direction;
    }

    private void Move()
    {
        SetDirection();
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        transform.forward = Vector3.Lerp(transform.forward, _direction, _rotationSpeed * Time.deltaTime).normalized;
    }

    private void SetColor()
    {
        _body.SetColor(Color);
    }

    private void SetDirection()
    {
        _direction = (_target.transform.position - transform.position).normalized;
    }
}
