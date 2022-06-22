using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController_unity : AnimController_base
{

    Animator animator;

    playerController.PLAYER_STATE oldState;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ChangeAnim(playerController.PLAYER_STATE curentState)
    {
        if (curentState == oldState)
            return;


        for (int i = 0; i<= (int)playerController.PLAYER_STATE.JUMP; i++)
        {
            animator.SetBool(((playerController.PLAYER_STATE)i).ToString(), false);
        }

        switch (curentState)
        {
            case playerController.PLAYER_STATE.IDLE:
                animator.SetBool(playerController.PLAYER_STATE.IDLE.ToString(),true);
                break;

            case playerController.PLAYER_STATE.WALK:
                animator.SetBool(playerController.PLAYER_STATE.WALK.ToString(), true);
                break;

            case playerController.PLAYER_STATE.JUMP:
                animator.SetBool(playerController.PLAYER_STATE.JUMP.ToString(), true);
                break;
        }

        oldState = curentState;
    }

}
