using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 생성할 총알 프리팹
    public GameObject BulletPrefab;
    public GameObject SubBulletPrefab;

    // 총구
    public GameObject LeftFirePosition;
    public GameObject RightFirePosition;
    public GameObject SubLeftFirePosition;
    public GameObject SubRightFirePosition;

    // 총알 쿨타입
    public float CoolTime = 0.6f;
    private float _coolTimer = 0;
    // 자동 발사
    private bool _autoFireMode = false;

    public void SetAuto(bool auto)
    {
        _autoFireMode = auto;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _autoFireMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _autoFireMode = false;
        }

        _coolTimer -= Time.deltaTime;

        // 총알 발사 쿨타임이 돌아왔을때, Fire 버튼이 눌리거나 자동 공격 모드면
        if (_coolTimer <= 0 && (Input.GetButtonDown("Fire1") || _autoFireMode))
        {
            Fire();

            float finalFireRate = CoolTime - UpgradeManager.Instance.Upgrades[1].CurrentValue;
            _coolTimer = CoolTime;
        }
    }

    // 목표: 총알을 만들어서 발사하고 싶다.
    public void Fire()
    {
        //  프리팹으로부터 총알 만들기
        Bullet rightBullet = BulletPool.Instance.GetBullet(BulletType.Main);
        Bullet leftBullet = BulletPool.Instance.GetBullet(BulletType.Main);
        Bullet subRightBullet = BulletPool.Instance.GetBullet(BulletType.Sub);
        Bullet subLeftBullet = BulletPool.Instance.GetBullet(BulletType.Sub);

        // 총알 위치를 총구 위치로 바꾸기
        rightBullet.transform.position = RightFirePosition.transform.position;
        leftBullet.transform.position = LeftFirePosition.transform.position;
        subRightBullet.transform.position = SubRightFirePosition.transform.position;
        subLeftBullet.transform.position = SubLeftFirePosition.transform.position;
    }

    public void FireSpeedUp()
    {
        CoolTime -= 0.1f;
        if (CoolTime <= 0.1f)
        {
            CoolTime = 0.1f;
        }
    }
}