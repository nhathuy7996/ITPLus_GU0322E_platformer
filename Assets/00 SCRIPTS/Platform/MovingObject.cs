using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    List<Vector3> Points = new List<Vector3>();

    [SerializeField]
    int currentIndex = -1;

    [SerializeField]
    bool way = false;

    Vector3 initPos;
    // Start is called before the first frame update
    void Awake()
    {
        initPos = this.transform.position;
        Points = this.GetComponent<PathCreator>().List_Points;
    }

    // Update is called once per frame
    void Update()
    {
        

       // Debug.Log(Vector2.Distance(this.transform.position, Points[currentIndex + 1] + initPos));

        if (Vector2.Distance(this.transform.position, Points[currentIndex + 1] + initPos) < 0.3f)
        {
            if (!way)
                currentIndex += 1;
            else
                currentIndex -= 1;

            //currentIndex += way ? -1 : 1;
        }

        if (currentIndex >= Points.Count-1 && !way)
        {
            way = !way;
            currentIndex = Points.Count - 2;
        }else if (currentIndex < 0 && way)
        {
            way = !way;
        }


         
        this.transform.position = Vector3.MoveTowards(this.transform.position, Points[currentIndex + 1] + initPos, Speed * Time.deltaTime );
    }

    


}
