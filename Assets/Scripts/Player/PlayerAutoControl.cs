using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerAutoControl : MonoBehaviour
{

    //移动速度
    [SerializeField]
    private float moveSpeed = 10f;

    //移动方向
    [SerializeField]
    private Vector3 moveDirection = new Vector3(0, 0, 1);

    private ThirdPersonCharacter control;

    //当前跑道
    private GameObject currentWay;

    private void Awake()
    {
        control = GetComponent<ThirdPersonCharacter>();
    }
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.moveSpeed = GameManager.Instance.playInfo.MoveSpeed;

        //检测按键
        if (Input.GetKeyDown(KeyCode.D))
        {
            //control.m
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //control.m
            transform.Rotate(0, -90, 0);
        }

        //计算，一定要让他在跑道中间

        //自动寻路移动

        Vector3 move = new Vector3(moveSpeed * Time.deltaTime * moveDirection.x, 0, moveSpeed * Time.deltaTime * moveDirection.z);
        control.Move(move, false, false);


    }
}
