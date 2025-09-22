using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        Move();
    }

    public void SetDirection(Vector3 direction)
    {
        transform.forward = direction;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
