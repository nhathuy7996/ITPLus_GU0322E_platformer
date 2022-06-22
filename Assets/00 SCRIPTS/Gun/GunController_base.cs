using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunController_base : MonoBehaviour
{
    [SerializeField]
    protected float AtkSpeed;

    protected float CountDown = 0;

    private void Awake()
    {
        CountDown = 0;
    }

    public abstract void Fire(float way);
}
