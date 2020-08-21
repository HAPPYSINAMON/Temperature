using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMachine : MonoBehaviour, IDefender, IAttacker
{
    [Header("속도, 반지름")]

    [SerializeField] [Range(0f, 10f)] private float speed = 1;
    [SerializeField] [Range(0f, 10f)] private float radius = 1;

    public bool Enemy = false;
    public int num = 0;
    public Transform ControlCoreTrans;
    
    private float runningTime = 0;
    private Vector2 newPos = new Vector2();

    void Start()
    {
        runningTime = num * 400;
        if(ControlCoreTrans == null)
        {
            ControlCoreTrans = GetComponentInParent<ControlCore>().gameObject.transform;
        }
    }

    // Use this for initialization
    void Update()
    {
        runningTime += Time.deltaTime * speed;
        if (!IsDie())
        {
            float x = radius * Mathf.Cos(runningTime) + ControlCoreTrans.position.x;
            float y = radius * Mathf.Sin(runningTime) + ControlCoreTrans.position.y;
            newPos = new Vector2(x, y);
            this.transform.position = newPos;
        }
    }

    public int HP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CharacterState characterState { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void DamageProcess(int damage)
    {
        throw new System.NotImplementedException();
    }

    public int GetATK()
    {
        throw new System.NotImplementedException();
    }

    public int GetDef()
    {
        throw new System.NotImplementedException();
    }

    public bool IsDie()
    {
        throw new System.NotImplementedException();
    }
}
