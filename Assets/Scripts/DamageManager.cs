using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static int Damage(IAttacker attacker, IDefender defender)
    {
        int damage = 0;
        int def = defender.GetDef();
        int atk = attacker.GetATK();

        damage = (def - atk) * -1;

        if (damage <= 0)
            damage = 0;

        return damage;
    }
}
