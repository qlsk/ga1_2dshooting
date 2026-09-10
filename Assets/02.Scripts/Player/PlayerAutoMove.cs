using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GameObject _targetEnemy = null;
    private GameObject _targetItem = null;
    [SerializeField] private float _stopTrackingY = -2;
    private float _enemyDistance;
    private float _itemDistance;

    enum target
    {
        Enemy,
        Item
    }

    private target _target;

    private void Start()
    {
    }

    private void Update()
    {
        if (_targetEnemy == null || _targetItem == null || _targetEnemy.transform.position.y < _stopTrackingY)
        {
            FindNearestTarget();
        }

        switch (_target)
        {
            case target.Enemy:
                MoveToEnemy();
                break;
            case target.Item:
                MoveToItem();
                break;
        }
    }

    private void MoveToEnemy()
    {
        if (_targetEnemy == null) return;

        // 2. 방향을 구한다.
        Vector3 diff = _targetEnemy.transform.position - transform.position;
        Vector3 direction = diff;

        // 적과 나와의 y축 차이가 3보다 크면 앞으로 가고 아니라면 뒤로 가게
        if (diff.y >= 3)
        {
            direction.y = 1;
        }
        else
        {
            direction.y = -1;
        }

        direction.Normalize();

        // 3. 속도에 맞게 이동을 한다.
        transform.position += _speed * Time.deltaTime * direction;
    }

    private void MoveToItem()
    {
        if (_targetItem == null) return;

        Vector3 direction = _targetItem.transform.position - transform.position;
        direction.Normalize();
        transform.position += _speed * Time.deltaTime * direction;
    }

    public void FindNearestTarget()
    {
        // 1. 타겟을 구한다.
        GameObject[] targetsEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (targetsEnemy.Length != 0)
        {
            _enemyDistance = FindNearestEnemy(targetsEnemy);
        }

        GameObject[] targetsItem = GameObject.FindGameObjectsWithTag("Item");
        if (targetsItem.Length != 0)
        {
            _itemDistance = FindNearestItem(targetsItem);
        }

        _target = _enemyDistance > _itemDistance ? target.Item : target.Enemy;
    }

    public float FindNearestItem(GameObject[] items)
    {
        _targetItem = items[0];
        float itemMinDistance = float.MaxValue;
        foreach (GameObject item in items)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if (distance < itemMinDistance && item.transform.position.y < -0.5f)
            {
                itemMinDistance = distance;
                _targetItem = item;
            }
        }

        return itemMinDistance;
    }

    public float FindNearestEnemy(GameObject[] enemies)
    {
        _targetEnemy = enemies[0];
        float enemyMinDistance = float.MaxValue;
        // 1-1. 가장 가까운 타겟을 찾는다.
        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.y < _stopTrackingY)
            {
                continue;
            }

            // 거리를 구해서
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < enemyMinDistance) // 저장된 거리보다 짧다면
            {
                // 타겟 변경
                enemyMinDistance = distance;
                _targetEnemy = enemy;
            }
        }

        return enemyMinDistance;
    }
}