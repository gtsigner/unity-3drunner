using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RunWay : MonoBehaviour
{


    //points
    private List<Transform> points;
    private int targetWayPointIndex;

    public List<Transform> Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
        }
    }

    private void Awake()
    {
        //获取points
        points = new List<Transform>();
        this.Init();


        //往那个目标点移动
        targetWayPointIndex = 1;
    }

    private void Init()
    {
        int i = 0;
        while (true)
        {
            Transform tmpTrf = this.transform.Find("Point_" + i);
            if (tmpTrf == null)
            {
                //points[i] = tmpTrf.gameObject;

                break;
            }
            else
            {
                points.Add(tmpTrf);
                i++;
            }
        }
    }


    private Vector3 GetNextTargetPoint()
    {

        return Vector3.zero;
    }



    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
