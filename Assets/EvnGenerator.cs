using UnityEngine;
using System.Collections;

public class EvnGenerator : MonoBehaviour
{

    //当前Player运动的路径
    public GameObject currentRunWay;

    //Player进入的下一条路径
    public GameObject nextRunWay;

    public GameObject[] envPrefabs;

    //升级预设
    public GameObject upLevelPrefab;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {


    }

    //生成路径
    void GeneratorWay(bool upLevel)
    {
        if (upLevel)
        {
            this.currentRunWay = this.nextRunWay;
            this.nextRunWay = Instantiate(upLevelPrefab) as GameObject;
        }
        else
        {
            int rand = Random.Range(0, envPrefabs.Length);
            this.currentRunWay = this.nextRunWay;
            this.nextRunWay = Instantiate(envPrefabs[rand]) as GameObject;
        }

        this.nextRunWay.transform.position = this.currentRunWay.transform.Find("PointEnd").position;

        this.nextRunWay.transform.forward = this.currentRunWay.transform.Find("PointEnd").forward;
    }

    private float timer = 3;
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 3)
        {
            GeneratorWay(false);
            timer = 0;
        }
        //定期生成Uplevel
    }
}
