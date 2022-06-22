using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    [SerializeField] GameObject bulletPrefab;

    List<GameObject> bulletList = new List<GameObject>();

    public GameObject getBullet(Vector3 posSpaw)
    {
        foreach (GameObject g in bulletList)
        {
            if (g.activeSelf)
                continue;

            g.transform.position = posSpaw;
            return g;
        }

        GameObject g2 = Instantiate(bulletPrefab, posSpaw, Quaternion.identity);

        bulletList.Add(g2);

        return g2;
    }
}
