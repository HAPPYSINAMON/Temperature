using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField] CharacterBullet bulletPrefab;
    [SerializeField] Transform firePosition;
    [SerializeField] GameObject shopWindow;

    Factory bulletFactory;

    Vector3 targetPos;

    Character player;
    Rigidbody2D theRB;

    float moveSpeed;

    private PhotonView pv;

    private void Awake()
    {
        player = GetComponent<Character>();
        theRB = GetComponent<Rigidbody2D>();

        theRB.bodyType = RigidbodyType2D.Dynamic;
        theRB.gravityScale = 0f;
        theRB.freezeRotation = true;
    }

    private void Start()
    {
        moveSpeed = player.Dex;

        bulletFactory = new Factory(bulletPrefab);
        targetPos = transform.position;

        if (pv.IsMine)
        {
            Camera.main.GetComponent<CameraPlayer>().target = this.gameObject;
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (shopWindow.activeSelf == true)
            return;

        if (Input.GetMouseButtonDown(1))
        {
            targetPos = OnMoveButtonPressed(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void OnFireButtonPressed(Vector3 position)
    {
        if (shopWindow.activeSelf == true)
            return;

        CharacterBullet bullet = bulletFactory.Get() as CharacterBullet;
        bullet.SetATK(player.Atk);
        bullet.Activate(firePosition.position, position);
        bullet.Destroyed += OnBulletDestroyed;
    }

    Vector3 OnMoveButtonPressed(Vector3 position)
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(position);
        point.z = 0f;

        return point;
    }

    void OnBulletDestroyed(RecycleObject usedBullet)
    {
        if (usedBullet is CharacterBullet)
            usedBullet.GetComponent<CharacterBullet>().ResetATK();
        usedBullet.Destroyed -= OnBulletDestroyed;
        bulletFactory.Restore(usedBullet);
    }
}
