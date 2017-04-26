using UnityEngine;
using System.Collections;

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
