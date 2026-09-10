using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private GameObject _enemy = null;
    private Vector2 _dir;

    private void Start()
    {
    }

    private void Update()
    {
        // 1. 타겟을 구한다.
        GameObject target = GameObject.FindWithTag("Enemy");
        if (target == null) return;

        // 2. 방향을 구한다.
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        direction.y = 0;

        // 3. 속도에 맞게 이동을 한다.
        transform.position += _speed * Time.deltaTime * direction;

        // if ( _enemy == null || _enemy.transform.position.y < transform.position.y + 0.5f)
        // {
        //     GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //     foreach (GameObject enemy in Enemies)
        //     {
        //         if (enemy.transform.position.y < _enemy.transform.position.y)
        //         {
        //             _enemy = enemy;
        //         }
        //         else if (_enemy == null)
        //         {
        //             _enemy = enemy;
        //         }
        //     }
        // }
        // else
        // {
        //     _dir = new Vector2(0, _enemy.transform.position.x - transform.position.x);
        //     _dir.Normalize();
        //     transform.position += Speed * Time.deltaTime * (Vector3)_dir;
        // }


        // if (_enemy == null)
        // {
        //     _enemy = GameObject.FindGameObjectWithTag("Enemy");
        // }
        //
        // GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // foreach (GameObject en in Enemies)
        // {
        //     if (en.transform.position.y < _enemy.transform.position.y && _enemy.transform.position.y - 1f < transform.position.y)
        //     {
        //         _enemy = en;
        //     }
        //     else
        //     {
        //     }
        // }
        //
        //
        // _dir = new Vector2(_enemy.transform.position.x - transform.position.x, 0);
        // _dir.Normalize();
        // transform.position += Speed * Time.deltaTime * (Vector3)_dir;
    }
}