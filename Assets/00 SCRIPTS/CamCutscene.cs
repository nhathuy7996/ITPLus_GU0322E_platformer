using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<CameraMoving>().enabled = false;

        Camera.main.transform.position = Vector3.zero; //boss position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
