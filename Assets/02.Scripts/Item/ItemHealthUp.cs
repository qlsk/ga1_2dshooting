using UnityEngine;

public class ItemHealthUp : Item
{
    [SerializeField] private GameObject _acquireEffectPrefab;
    private void Start()
    {
        startPoint = transform.position;
        endPoint = startPoint - new Vector2(0, 1);
        middlePoint = startPoint + new Vector2(0.5f, -0.5f);
    }

    private void Update()
    {
        _startTimer -= Time.deltaTime;
        if (_startTimer <= 0)
        {
            if (transform.position.y <= endPoint.y)
            {
                direction = -1 * direction;
                startPoint = transform.position;
                endPoint = startPoint - new Vector2(0, 1);
                middlePoint = startPoint + new Vector2(direction, -0.5f);
                time = 0;
            }

            transform.position = BezierCurve(time);
            time += Time.deltaTime * _moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.HealthUp();
            Instantiate(_acquireEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}