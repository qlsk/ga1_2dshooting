using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _disappearTime = 3f;
    private float _timer = 0f;
    private float _scale = 0f;
    private float _maxScale = 1f;
    private float _scaleStayTime = 1f;
    private float _reduceTimer = 0f;
    private float _time;
    private float _positionY = 0f;
    [SerializeField] private GameObject _deathByBombEffectPrefab;

    private void Start()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _disappearTime)
        {
            Destroy(gameObject);
        }

        _positionY = Mathf.Lerp(0, 2f, 0.005f);
        transform.position += new Vector3(0, _positionY, 0);

        if (transform.localScale.x < _maxScale && _timer <= _scaleStayTime)
        {
            _scale = Mathf.Lerp(0, _maxScale, _timer);
            transform.localScale = new Vector3(_scale, _scale, _scale);
            _time = _timer;
        }
        else if (transform.localScale.x >= 0 && _timer >= _disappearTime - _time)
        {
            _reduceTimer += Time.deltaTime;
            _scale = Mathf.Lerp(_maxScale, 0, _reduceTimer);
            transform.localScale = new Vector3(_scale, _scale, _scale);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(_deathByBombEffectPrefab, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}