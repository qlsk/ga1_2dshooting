using UnityEngine;

public class HomingEnemy : Enemy
{
    private GameObject _player;
    private Vector2 _direction;
    private float _rotation;
    private float _x;
    private float _y;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        _direction = _player.transform.position - transform.position;
        _x = _direction.x;
        _y = _direction.y;
        _direction.Normalize();

        _rotation = Mathf.Atan2(_y, _x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, 90 + _rotation);
        // transform.Translate(_moveSpeed * Time.deltaTime * _direction);
        transform.position += _moveSpeed * Time.deltaTime * (Vector3)_direction;
    }
}