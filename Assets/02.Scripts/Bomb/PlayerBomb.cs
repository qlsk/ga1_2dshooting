using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    private float _bombCoolTime = 10f;
    private float _bombCoolTimer = 10f;
    [SerializeField] private GameObject _bombEffectPrefab;

    private void Start()
    {
    }

    private void Update()
    {
        _bombCoolTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.B) && (_bombCoolTimer >= _bombCoolTime))
        {
            Instantiate(_bombEffectPrefab, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
            _bombCoolTimer = 0;
        }
    }
}