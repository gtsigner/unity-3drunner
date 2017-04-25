using UnityEngine;
using System.Collections;

public class WaysSpawnController : MonoBehaviour
{

    public float positionY = 0.81f;
    public Transform[] WaysPrefabs;

    //当前人物在
    public Transform CurrentPath;

    public GameObject DangerousBorder;

    //检测
    void OnTriggerEnter(Collider hit)
    {

        //player has hit the collider
        if (hit.gameObject.tag == Constants.PlayerTag)
        {
            print("Player IN");
            //产生地图随机生成
            int randomSpawnPoint = Random.Range(0, WaysPrefabs.Length);
            for (int i = 0; i < WaysPrefabs.Length; i++)
            {
                //instantiate the path, on the set rotation
                if (i == randomSpawnPoint)
                {
                    //构建随机的下一次路径
                    Instantiate(WaysPrefabs[i], this.transform.parent.position, WaysPrefabs[i].rotation);
                }
            }

        }
    }
}
