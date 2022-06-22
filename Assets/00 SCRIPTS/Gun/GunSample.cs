using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSample : GunController_base
{

    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void Fire(float way)
    {
        _Gun_State = GUN_STATE.fire;
        way = way > 0 ? 1 : -1;

        if (CountDown > 0)
            return;

        CountDown = AtkSpeed;
        BulletController_base bullet = BulletManager.Instant.getBullet(this.transform.position).GetComponent<BulletController_base>();
        bullet.gameObject.SetActive(true);
        bullet.SetMovement(Vector3.right * way);
        
    }

   
}
