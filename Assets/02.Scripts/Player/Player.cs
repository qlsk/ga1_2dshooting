using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private GameObject _deathEffectPrefab;
    private AudioSource _damagedSound;

    private void Start()
    {
        _damagedSound = GetComponent<AudioSource>();
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
        else
        {
            _damagedSound.Play();
        }
    }

    public void HealthUp()
    {
        _health++;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(coll.gameObject);
        }
    }
}