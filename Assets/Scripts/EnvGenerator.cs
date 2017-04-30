using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvGenerator : MonoBehaviour
{

    //当前Player运动的路径
    public GameObject currentRunWay;

    //Player进入的下一条路径
    public GameObject centerRunWay;

    public GameObject lastRunWay;

    public GameObject[] envPrefabs;

    //升级预设
    public GameObject upLevelPrefab;

    //系统中存在得场景
    public Queue<GameObject> senceRunWays;

    private void Awake()
    {
        this.senceRunWays = new Queue<GameObject>();

        this.senceRunWays.Enqueue(currentRunWay);
        this.senceRunWays.Enqueue(centerRunWay);
        this.senceRunWays.Enqueue(lastRunWay);
    }

    // Use this for initialization
    void Start()
    {


    }

    //生成路径
    public void GeneratorWay(bool upLevel)
    {
        this.currentRunWay = this.centerRunWay;
        this.centerRunWay = this.lastRunWay;

        if (upLevel)
        {
            //升级楼层
            this.lastRunWay = Instantiate(upLevelPrefab) as GameObject;
        }
        else
        {
            int rand = Random.Range(0, envPrefabs.Length);
            this.lastRunWay = Instantiate(envPrefabs[rand]) as GameObject;
        }

        //衔接最后一个点

        RunWay tmpRunWay = this.centerRunWay.GetComponent<RunWay>() as RunWay;

        Transform theLastPoint = tmpRunWay.Points[tmpRunWay.Points.Count - 1];

        print(theLastPoint);

        this.lastRunWay.transform.position = theLastPoint.position;
        this.lastRunWay.transform.forward = theLastPoint.forward;

        //放到队列得尾部
        this.senceRunWays.Enqueue(this.lastRunWay);
        print(this.senceRunWays.Count);
        //销毁队列头部得对象

        Destroy(this.senceRunWays.Dequeue(), 1f);
    }

}
