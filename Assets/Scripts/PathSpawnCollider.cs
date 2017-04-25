using UnityEngine;
using System.Collections;

/// <summary>
/// 路径生成
/// </summary>
public class PathSpawnCollider : MonoBehaviour
{

    public float positionY = 0.81f;
    public Transform[] PathSpawnPoints;
    public GameObject Path;
    public GameObject DangerousBorder;

    void OnTriggerEnter(Collider hit)
    {
        //player has hit the collider
        if (hit.gameObject.tag == Constants.PlayerTag)
        {
            //随机生成
            int randomSpawnPoint = Random.Range(0, PathSpawnPoints.Length);
            for (int i = 0; i < PathSpawnPoints.Length; i++)
            {
                //instantiate the path, on the set rotation
                if (i == randomSpawnPoint)
                {
                    //构建随机的下一次路径
                    Instantiate(Path, PathSpawnPoints[i].position, PathSpawnPoints[i].rotation);
                }
                else
                {
                    //instantiate the border, but rotate it 90 degrees first
                    Vector3 rotation = PathSpawnPoints[i].rotation.eulerAngles;
                    rotation.y += 90;
                    Vector3 position = PathSpawnPoints[i].position;
                    position.y += positionY;
                    Instantiate(DangerousBorder, position, Quaternion.Euler(rotation));
                }
            }

        }
    }

}
