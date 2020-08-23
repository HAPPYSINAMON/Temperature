using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterBullet : RecycleObject
{
    float speed = 5f;
    public Team team;

    int _ATK = 10;

    public int ATK
    {
        get
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

    public GameObject target;

    private void Update()
    {
        if (!isActivated)
            return;
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (target == null)
                Destroy(this);
        }
        else
            transform.position += transform.up * speed * Time.deltaTime;

        if (IsArrivedToTarget())
        {
            isActivated = false;

            if (Destroyed != null)
            {
                Destroyed(this);
            }
        }
    }

    bool IsArrivedToTarget()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);

        return distance < 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isActivated = false;

        if (Destroyed != null)
            Destroyed(this);

        if (collision.gameObject.name == "Shop")
            return;
        else if (collision.gameObject.GetComponent<Character>() == null && collision.gameObject.GetComponent<GuardMachine>() == null)
            return;
        else if (collision.gameObject.GetComponent<Character>() != null && collision.gameObject.GetComponent<Character>().team != team)
        {
            Debug.Log("캐릭터 어택!");
            collision.gameObject.GetComponent<Character>().DamageProcess(ATK);
        }
        else if (collision.gameObject.GetComponent<GuardMachine>() != null && collision.gameObject.GetComponent<GuardMachine>().team != team)
        {
            Debug.Log("머신 어택!");
            collision.gameObject.GetComponent<GuardMachine>().DamageProcess(ATK);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isActivated = false;

        if (Destroyed != null)
            Destroyed(this);

        if (collision.gameObject.name == "Shop")
            return;
        else if (collision.gameObject.GetComponent<Character>().team != team)
        {
            Debug.Log("어택!");
            collision.gameObject.GetComponent<Character>().DamageProcess(ATK);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActivated = false;

        if (Destroyed != null)
            Destroyed(this);

        if (collision.gameObject.name == "Shop")
            return;
        else if (collision.gameObject.GetComponent<Character>() == null && collision.gameObject.GetComponent<GuardMachine>() == null)
            return;
        else if (collision.gameObject.GetComponent<Character>() != null && collision.gameObject.GetComponent<Character>().team != team)
        {
            Debug.Log("캐릭터 어택!");
            collision.gameObject.GetComponent<Character>().DamageProcess(ATK);
        }
        else if (collision.gameObject.GetComponent<GuardMachine>() != null && collision.gameObject.GetComponent<GuardMachine>().team != team)
        {
            Debug.Log("머신 어택!");
            collision.gameObject.GetComponent<GuardMachine>().DamageProcess(ATK);
        }
    }

    public void ResetATK()
    {
        ATK = 10;
    }

    public void SetATK(int value)
    {
        ATK = value;
    }
}
