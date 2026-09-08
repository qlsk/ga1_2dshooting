using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _disappearTime = 3f;
    private float _disappearTimer = 0f;

    private void Start()
    {
    }

    private void Update()
    {
        _disappearTimer += Time.deltaTime;
        if (_disappearTimer >= _disappearTime)
        {
            Destroy(gameObject);
            _disappearTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}