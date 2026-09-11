using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;

    // TODO: 에너미가 공격 당할 때 재생시켜주는 피격 사운드
    private AudioSource _damagedAudioSource;

    [SerializeField] private int _health = 10;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _damage;

    [SerializeField] Item _itemMoveSpeedUp;
    [SerializeField] Item _itemHealthUp;
    [SerializeField] Item _itemFireSpeedUp;
    private bool isDead = false;

    [SerializeField] ItemSpawnDataTableSO _itemSpawnDataTable;

    // 죽을 때 생성할 이펙트 프리팹
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Awake()
    {
        // 애니메이터 컴포넌트에 대한 참조를 가져와서 할당한다.
        _animator = GetComponent<Animator>();
        _damagedAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }


        _animator.SetTrigger("hit");
        // 충돌 시 체력 감소
        _health -= damage;

        // 체력이 0 이하라면
        if (_health <= 0)
        {
            isDead = true;
            SpawnItem();

            // ScoreManager scoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
            // ScoreManager scoreManager = ScoreManager.Instance;
            // scoreManager.AddScore(100);
            ScoreManager.Instance.AddScore(100);

            // 제거
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            _damagedAudioSource.Play();
        }
    }

    public void SpawnItem()
    {
        // 30퍼 확률로 아이템 생성
        int itemSpawnRandom = Random.Range(0, 100);

        if (itemSpawnRandom < 30f)
        {
            int totalWeight = 0;

            foreach (ItemSpawnData data in _itemSpawnDataTable.Datas)
            {
                totalWeight += data.Weight;
            }

            int randomWeight = Random.Range(0, totalWeight);

            int cumulativeWeight = 0;

            foreach (ItemSpawnData data in _itemSpawnDataTable.Datas)
            {
                cumulativeWeight += data.Weight;
                if (cumulativeWeight > randomWeight)
                {
                    Instantiate(data.itemPrefab, transform.position, Quaternion.identity);
                    break;
                }
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