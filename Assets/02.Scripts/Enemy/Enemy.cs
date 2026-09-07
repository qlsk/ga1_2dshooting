using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _damage;

    [SerializeField] Item _itemMoveSpeedUp;
    [SerializeField] Item _itemHealthUp;
    [SerializeField] Item _itemFireSpeedUp;
    private bool isDead = false;


    private void Start()
    {
    }

    private void Update()
    {
        // 1. 방향을 구한다.
        Vector3 dir = Vector3.down;

        // 2. 이동한다.
        transform.position += _moveSpeed * Time.deltaTime * dir;
    }

    public void TakeDamage(int damage)
    {
        // 충돌 시 체력 감소
        _health -= damage;
        if (isDead)
        {
            return;
        }

        // 체력이 0 이하라면
        if (_health <= 0)
        {
            isDead = true;
            SpawnItem();
            // 제거
            Destroy(gameObject);
        }
    }

    public void SpawnItem()
    {
        // 30퍼 확률로 아이템 생성
        int itemSpawnRandom = Random.Range(0, 100);
        if (itemSpawnRandom <= 30)
        {
            int whichItemSpawn = Random.Range(0, 3);
            Item item = null;
            // 아이템 3개 중 하나 스폰
            switch (whichItemSpawn)
            {
                case 0:
                    item = Instantiate(_itemFireSpeedUp);
                    item.transform.position = transform.position;
                    break;
                case 1:
                    item = Instantiate(_itemHealthUp);
                    item.transform.position = transform.position;
                    break;
                case 2:
                    item = Instantiate(_itemMoveSpeedUp);
                    item.transform.position = transform.position;
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Player player = other.gameObject.GetComponent<Player>();
        player.TakeDamage(1);
    }
}