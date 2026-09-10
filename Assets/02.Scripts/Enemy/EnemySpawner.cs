using UnityEngine;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [Header("스폰 간격")]
    [SerializeField] private float _spawnInterval = 3f;

    private float _timer;

    private int[] spawnNumber = new int[10] { 0, 0, 0, 0, 0, 1, 1, 1, 2, 2 };

    // - 생성할 프리팹
    [Header("downward 적 프리팹")]
    [SerializeField] private Enemy _downwardEnemyPrefab;

    [Header("aimed 적 프리팹")]
    [SerializeField] private Enemy _aimedEnemyPrefab;

    [Header("homing 적 프리팹")]
    [SerializeField] private Enemy _homingEnemyPrefab;

    private void Start()
    {
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0;

            _spawnInterval = Random.Range(1f, 3f); // float: 1 ~ 3
            // int randomInt = Random.Range(1, 3); // int: 1 ~ 2
            Spawn();
        }
    }

    private void Spawn()
    {
        int randomNumber = Random.Range(0, spawnNumber.Length);

        Enemy enemy = null;

        switch (spawnNumber[randomNumber])
        {
            case 0:
                enemy = Instantiate(_downwardEnemyPrefab);
                enemy.transform.position = transform.position;
                break;
            case 1:
                enemy = Instantiate(_aimedEnemyPrefab);
                enemy.transform.position = transform.position;
                break;
            case 2:
                enemy = Instantiate(_homingEnemyPrefab);
                enemy.transform.position = transform.position;
                break;
        }
    }
}