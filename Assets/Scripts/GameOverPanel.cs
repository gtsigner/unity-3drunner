using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{


    private Button settingBtn;
    private Button replayBtn;
    private Button backBtn;
    private Text scoreText;
    private Text floorText;

    private void Awake()
    {
        //初始化组件
        //TODO 优化，先找到bg，然后使用bg去find
        this.settingBtn = transform.Find("BackGround/SettingBtn").GetComponent<Button>();
        this.replayBtn = transform.Find("BackGround/ReplayBtn").GetComponent<Button>();
        this.backBtn = transform.Find("BackGround/BackBtn").GetComponent<Button>();
        this.scoreText = transform.Find("BackGround/ScoreBg/ScoreLabel").GetComponent<Text>();
        this.floorText = transform.Find("BackGround/FloorBg/FloorLabel").GetComponent<Text>();
        GameManager.Instance.playInfoChangeEvent += Instance_playInfoChangeEvent;
    }

    private void Instance_playInfoChangeEvent(PlayInfoModel playInfo)
    {
        //更新信息
        this.scoreText.text = playInfo.Score + "M";
        this.floorText.text = playInfo.FloorCount.ToString() + "F";
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
