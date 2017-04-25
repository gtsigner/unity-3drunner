using UnityEngine;
using System.Collections;

public class SettingManager : MonoBehaviour
{

    //系统设置控制器

    private static SettingManager _instance;

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
    }
    //
    public float MusicVoice = 100;
    public KeyCode JumpInput = KeyCode.Space;
    public KeyCode LeftRotat = KeyCode.A;
    public KeyCode RightRotat = KeyCode.A;
    public KeyCode PlayAndPause = KeyCode.Escape;

    public static SettingManager Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
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
