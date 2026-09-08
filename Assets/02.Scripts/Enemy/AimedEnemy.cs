using UnityEngine;

public class AimedEnemy : Enemy
{
    private GameObject _player;
    private Vector2 _direction;


    private void Start()
    {
        float _rotation;
        float _x;
        float _y;
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Destroy(gameObject);
            return;
        }
        _direction = _player.transform.position - transform.position;
        _x = _direction.x;
        _y = _direction.y;
        _direction.Normalize();

        _rotation = Mathf.Atan2(_y, _x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, 90 + _rotation);
    }

    private void Update()
    {
        // transform.Translate(_moveSpeed * Time.deltaTime * _direction);
        transform.position += _moveSpeed * Time.deltaTime * (Vector3)_direction;
    }
}