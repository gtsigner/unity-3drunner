using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Obstacle : MonoBehaviour
{

    //box and barrel found here: https://www.assetstore.unity3d.com/en/#!/content/11256



    /// <summary>
    /// 障碍物碰撞检测
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        //if the player hits one obstacle, it's game over
        if (col.gameObject.tag == Constants.PlayerTag)
        {
            GameManager.Instance.PlayerDie();
        }
    }
}
