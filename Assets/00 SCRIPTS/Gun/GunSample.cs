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
        if (CountDown > 0)
            CountDown -= Time.deltaTime;
    }

    public override void Fire(float way)
    {

        way = way > 0 ? 1 : -1;

        if (CountDown > 0)
            return;

        CountDown = AtkSpeed;
        BulletController_base bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity).GetComponent<BulletController_base>();

        bullet.SetMovement(Vector3.right * way);
        
    }

   
}
