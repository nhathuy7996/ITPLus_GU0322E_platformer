using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCam : MonoBehaviour
{
    [SerializeField] Transform player, boss;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = ((Vector2)boss.position + (Vector2)player.position) / 2;
        pos.z = -10;
        this.transform.position = pos;

        if (Vector2.Distance(player.position, boss.position) / 2 < 10)
            return;
        cam.orthographicSize = Vector2.Distance(player.position, boss.position) / 2;

    }
}
