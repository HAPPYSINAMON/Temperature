using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IAttacker, IDefender
{
    int _currentHP;
    int _currentMP;

    public string Name { get; set; }
    public int MaxHP { get; set; }
    public int CurrentHP { get
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
    public int MaxMP { get; set; }
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

    public int Atk { get; set; }
    public int Def { get; set; }
    public int Intelligence { get; set; }
    public int Dex { get; set; }
    public int Resist_Hot { get; set; }
    public int Resist_Cold { get; set; }
    public int Attack_Range { get; set; }
    public int Attack_Speed { get; set; }


    public CharacterState characterState { get; set; }

    public static Character player;

    private void Awake()
    {
        if (player == null)
            player = this;
    }

    public void DamageProcess(int damage)
    {
        MaxHP -= damage;
        if (MaxHP <= 0)
            characterState = CharacterState.DIE;
    }

    public int GetMaxHP()
    {
        return MaxHP;
    }

    public void SetMaxHP(int value)
    {
        MaxHP += value;
    }

    public int GetCurrentHP()
    {
        if (CurrentHP < 0)
            CurrentHP = 0;
        else if (CurrentHP > MaxHP)
            CurrentHP = MaxHP;

        return CurrentHP;
    }

    public int GetATK()
    {
        return Atk;
    }

    public void SetATK(int value)
    {
        Atk += value;
    }

    public int GetDef()
    {
        return Def;
    }

    public void SetDef(int value)
    {
        Def += value;
    }

    public bool IsDie()
    {
        if (characterState == CharacterState.DIE)
            return true;
        else
            return false;
    }

    public int GetResistHot()
    {
        return Resist_Hot;
    }

    public void SetResistHot(int value)
    {
        Resist_Hot += value;
    }

    public int GetResistCold()
    {
        return Resist_Cold;
    }

    public void SetResistCold(int value)
    {
        Resist_Cold += value;
    }
}
