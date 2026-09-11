using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("이동속도")]
    public float Speed = 5f;

    public int Damage;

    private bool _isHit = false;

    private AudioSource _bulletSound;

    private void Awake()
    {
        _bulletSound = GetComponent<AudioSource>();
    }

    // 활성화 될때마다 자동으로 호출되는 이벤트 함수

    public void OnSpawn()
    {
        // 프리팹이 풀에 의해서 활성화 될때마다
        // 초기화 하는 코드들이 들어간다.
        PlaySound();
        _isHit = false;
    }

    private void PlaySound()
    {
        Debug.Log("총알 활성화");
        _bulletSound.pitch = Random.Range(0.9f, 1.1f);
        _bulletSound.Play();
    }

    private void Update()
    {
        transform.position += Speed * Time.deltaTime * Vector3.up;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isHit)
            return;

        Enemy enemy = other.GetComponentInParent<Enemy>();

        if (enemy == null)
            return;

        _isHit = true;

        enemy.TakeDamage(Damage);

        gameObject.SetActive(false);
    }
}