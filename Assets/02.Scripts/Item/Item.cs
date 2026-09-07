using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected float _startTimer;
    [SerializeField] protected float _moveSpeed;
    protected Vector2 startPoint;
    protected Vector2 endPoint;
    protected Vector2 middlePoint;
    protected float time = 0;
    protected int direction = 1;

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

    public Vector2 BezierCurve(float t)
    {
        return (1 - t) * (1 - t) * startPoint + 2 * t * (1 - t) * middlePoint + t * t * endPoint;
    }
}