using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMachine : MonoBehaviour
{
    int _currentHP = 200;
    int _maxHP = 200;
    int _ATK = 20;
    const int _baseATK = 20;

    int HP
    {
        get
        {
            if (_currentHP < 0)
            {
                _currentHP = 0;
                IsDead();
            }
            else if (_currentHP > _maxHP)
                _currentHP = _maxHP;

            return _currentHP;
        }
        set
        {
            _currentHP = value;
        }
    }
    int ATK
    {
        get
        {
            if (_ATK < _baseATK)
                _ATK = _baseATK;
            return _ATK;
        }
        set
        {
            _ATK = value;
        }
    }

    public float radius_target = 1f;
    public Team team = Team.RED;
    public bool isDead = false;

    public float time = 0.0f;
    public float Settime = 1.5f;

    [SerializeField] CharacterBullet bulletPrefab;
    Factory bulletFactory;

    private void Awake()
    {
        bulletFactory = new Factory(bulletPrefab);
    }

    public void HealHP(int value)
    {
        if (HP < 200)
        {
            _currentHP += value;
        }
    }
    public void DamageProcess(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            IsDead();
        }
    }

    public void Rebrith()
    {
        isDead = false;
        _currentHP = 200;
        gameObject.SetActive(true);
    }

    public void ShootBullet(GameObject target)
    {
        if (time >= Settime)
        {
            time = 0;
            //bulletPrefab.GetComponent<Bullet>().target = target;
            //Instantiate(bulletPrefab, transform.position, transform.rotation);
            CharacterBullet bullet = bulletFactory.Get() as CharacterBullet;
            bullet.target = target;
            bullet.SetATK(ATK);
            bullet.Activate(transform.position, target.transform.position);
            bullet.Destroyed += OnBulletDestroyed;
        }
    }
    void IsDead()
    {
        Debug.Log("Destroyed!");
        gameObject.SetActive(false);
    }

    void OnBulletDestroyed(RecycleObject usedBullet)
    {
        if (usedBullet is CharacterBullet)
            usedBullet.GetComponent<CharacterBullet>().ResetATK();
        usedBullet.Destroyed -= OnBulletDestroyed;
        bulletFactory.Restore(usedBullet);
    }
}
