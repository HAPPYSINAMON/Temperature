using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Team team = Team.BLUE;
    public CharacterState state;

    string _Name;
    public string Name;

    int _maxHP = 500;
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }
    public int _currentHP = 50;
    public int CurrentHP
    {
        get
        {
            if (_currentHP < 0)
                _currentHP = 0;
            else if (_currentHP > MaxHP)
                _currentHP = MaxHP;
            return _currentHP;
        }
        set
        {
            _currentHP = value;
        }
    }
    int _maxMP = 100;
    public int MaxMP { get { return _maxMP; } set { _maxMP = value; } }
    int _currentMP = 500;
    public int CurrentMP
    {
        get
        {
            if (_currentMP < 0)
                _currentMP = 0;
            else if (_currentMP > MaxMP)
                _currentMP = MaxMP;
            return _currentMP;
        }
        set
        {
            _currentMP = value;
        }
    }

    int _ATK = 10;
    public int Atk
    { get
        {
            if (_ATK < 10)
                _ATK = 10;
            return _ATK;
        }
        set
        {
            _ATK = value;
        }
    }
    int _Def = 10;
    public int Def
    {
        get
        {
            if (_Def < 10)
                _Def = 10;
            return _Def;
        }
        set
        {
            _Def = value;
        }
    }
    int _Intelligence = 10;
    public int Intelligence
    {
        get
        {
            if (_Intelligence < 10)
                _Intelligence = 10;
            return _Intelligence;
        }
        set
        {
            _Intelligence = value;
        }
    }

    int _Dex = 10;
    public int Dex
    {
        get
        {
            if (_Dex < 10)
                _Dex = 10;
            return _Dex;
        }
            set
        {
            _Dex = value;
        }
    }
    int _ResistHot = 0;
    public int Resist_Hot
    {
        get
        {
            if (_ResistHot < 0)
                _ResistHot = 0;
            return _ResistHot;
        }
        set
        {
            _ResistHot = value;
        }
    }
    int _ResistCold = 0;
    public int Resist_Cold
    {
        get
        {
            if (_ResistCold < 0)
                _ResistCold = 0;
            return _ResistCold;
        }
        set
        {
            _ResistCold = value;
        }
            }

    public static Character player;

    private void Awake()
    {
        if (player == null)
            player = this;

        state = CharacterState.IDLE;
    }

    public void DamageProcess(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            IsDead();
        }
    }

    public void SetHP(int value)
    {
        _currentHP += value;
    }

    public int GetHP()
    {
        return _currentHP;
    }

    public void UseHP(int value)
    {
        _currentHP -= value;
    }

    public void SetMP(int value)
    {
        _currentMP += value;
    }

    public int GetMP()
    {
        return _currentMP;
    }

    public void UseMP(int value)
    {
        _currentMP -= value;
    }

    public void SetATK(int value)
    {
        _ATK += value;
    }


    public void SetDef(int value)
    {
        _Def += value;
    }

    public void SetResistHot(int value)
    {
        Resist_Hot += value;
    }

    public void SetResistCold(int value)
    {
        _ResistCold += value;
    }

    void IsDead()
    {
        Debug.Log("Die");
        state = CharacterState.DIE;
        gameObject.SetActive(false);
    }
}
