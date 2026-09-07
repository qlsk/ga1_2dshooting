using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator _animator;

    private void Start()
    {
    }

    private void Awake()
    {
        // 애니메이터 컴포넌트에 대한 참조를 가져와서 할당한다.
        _animator = GetComponent<Animator>();
    }

    public float Speed = 5f;
    public float MaxPositionY;
    public float MinPositionY;
    public float MaxPositionX;
    public float MinPositionX;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(h, v);
        dir = dir.normalized;
        transform.position += Speed * Time.deltaTime * (Vector3)dir;

        _animator.SetInteger("x", (int)dir.x);

        if (transform.position.y < MinPositionY)
        {
            transform.position = new Vector2(transform.position.x, MinPositionY);
        }
        else if (transform.position.y > MaxPositionY)
        {
            transform.position = new Vector2(transform.position.x, MaxPositionY);
        }

        if (transform.position.x < MinPositionX)
        {
            transform.position = new Vector2(MaxPositionX, transform.position.y);
        }
        else if (transform.position.x > MaxPositionX)
        {
            transform.position = new Vector2(MinPositionX, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed--;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Speed++;
        }
    }

    public void MoveSpeedUp()
    {
        Speed++;
    }
}