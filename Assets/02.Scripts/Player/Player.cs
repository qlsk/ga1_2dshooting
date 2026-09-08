using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void HealthUp()
    {
        _health++;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
            Destroy(coll.gameObject);
        }
    }
}