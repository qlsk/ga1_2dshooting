using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _disappearTime = 3f;
    private float _timer = 0f;
    private float _scale = 0f;
    private float _scaleStayTime = 0.5f;
    private float _scaleReductionTime = 2.5f;
    private float _scaleReductionTimer = 0f;
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
            _timer = 0f;
        }

        if (_timer < _scaleStayTime)
        {
            _scale += Time.deltaTime * 0.03f;
            transform.localScale += new Vector3(_scale, _scale, _scale);
        }
        else if (_timer > _scaleReductionTime)
        {
            _scale += Time.deltaTime * 0.03f;
            transform.localScale -= new Vector3(_scale, _scale, _scale);
        }
        else
        {
            _scale = 0;
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