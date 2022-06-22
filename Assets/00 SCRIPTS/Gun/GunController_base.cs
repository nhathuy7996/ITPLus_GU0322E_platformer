using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunController_base : MonoBehaviour
{
    [SerializeField]
    protected float AtkSpeed;

    protected float CountDown = 0;

    protected GUN_STATE _Gun_State = GUN_STATE.idle;

    public GUN_STATE Gun_State => _Gun_State;

    public enum GUN_STATE
    {
        idle,
        fire
    }

    private void Awake()
    {
        CountDown = 0;
    }


    protected void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            this.Fire(this.transform.parent.localScale.x);
        }

        if (CountDown > 0)
            CountDown -= Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.C))
        {
            _Gun_State = GUN_STATE.idle;
        }
    }


    public abstract void Fire(float way);
}
