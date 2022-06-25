using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    [SerializeField] List<Vector2> Point = new List<Vector2>();

    [SerializeField]
    int currentIndex = -1;

    [SerializeField]
    bool way = false;

    Vector2 initPos;
    // Start is called before the first frame update
    void Awake()
    {
        initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
   

        Debug.Log(Vector2.Distance(this.transform.position, Point[currentIndex + 1] + initPos));

        if (Vector2.Distance(this.transform.position, Point[currentIndex + 1] + initPos) < 0.3f)
        {
            if (!way)
                currentIndex += 1;
            else
                currentIndex -= 1;

            //currentIndex += way ? -1 : 1;
        }

        if (currentIndex >= Point.Count-1 && !way)
        {
            way = !way;
            currentIndex = Point.Count - 2;
        }else if (currentIndex < 0 && way)
        {
            way = !way;
        }


         
        this.transform.position = Vector3.MoveTowards(this.transform.position, Point[currentIndex + 1] + initPos, Speed * Time.deltaTime );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < Point.Count - 1; i++)
        {
            Gizmos.DrawLine(this.Point[i] + initPos, this.Point[i + 1] + initPos);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //initPos = this.transform.position;
    }


}
