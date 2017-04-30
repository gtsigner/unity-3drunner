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

    private EnvGenerator envGenerator;

    private int UpSpace = 10;

    //当前跑道
    private GameObject currentWay;

    private void Awake()
    {
        control = GetComponent<ThirdPersonCharacter>();
        envGenerator = GameObject.Find("ScriptHolder").GetComponent<EnvGenerator>();

    }
    // Use this for initialization
    void Start()
    {


    }

    //获取当前在哪一个对象地面上面,通过射线法
    private GameObject GetCurrentWayIn()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo))
        {
            GameObject gameObj = hitInfo.collider.gameObject;
            return gameObj;
        }
        else
        {
            return null;
        }
    }

    // Update is called once per frame
    void Update()
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
        GameObject obj = this.GetCurrentWayIn();
        if (obj != null)
        {
            if (obj.transform.parent.gameObject != envGenerator.currentRunWay)
            {
                //是否升级难度
                bool isUp = (GameManager.Instance.playInfo.Score % UpSpace) == 0 ? true : false;
                if (isUp)
                {
                    UpSpace += 5;
                    //增加人物移动速度
                }
                envGenerator.GeneratorWay(isUp);

            }

        }




        //自动寻路移动


        Vector3 move = new Vector3(moveSpeed * Time.deltaTime * moveDirection.x, 0, moveSpeed * Time.deltaTime * moveDirection.z);

        control.Move(move, false, false);


    }
}
