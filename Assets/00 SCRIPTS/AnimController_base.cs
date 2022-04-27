using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimController_base : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public abstract void ChangeAnim(playerController.PLAYER_STATE curentState);
}
