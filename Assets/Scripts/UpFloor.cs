using UnityEngine;
using System.Collections;

/// <summary>
/// 楼层碰撞检测
/// </summary>
public class UpFloor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.PlayerTag)
        {
            //更新楼层，增加移动速度
            GameManager.Instance.UpFloor();
        }
    }
}
