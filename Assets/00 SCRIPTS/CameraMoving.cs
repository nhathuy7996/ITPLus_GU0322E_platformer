using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] playerController player;
    [SerializeField] float Speed = 1;

    [SerializeField] Vector2 camOffset = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        Vector3 pos = player.transform.position + (Vector3)camOffset;
        pos.z = this.transform.position.z;


        this.transform.position = Vector3.MoveTowards(this.transform.position, pos, Speed * Time.deltaTime);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
            return;

        if (player == null)
            return;
        Vector3 pos = player.transform.position + (Vector3)camOffset;
        pos.z = this.transform.position.z;

        this.transform.position = pos;
    }
#endif
}
