using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayingPanel : MonoBehaviour
{

    //
    private Text scoreText;
    private Text floorText;
    private Button pauseButton;




    private void Awake()
    {
        _init();
    }

    private void _init()
    {
        this.scoreText = this.transform.Find("ScoreText").GetComponent<Text>();
        this.floorText = this.transform.Find("FloorText").GetComponent<Text>();
        this.pauseButton = this.transform.Find("PauseBtn").GetComponent<Button>();

        //增加委托事件
        GameManager.Instance.playInfoChangeEvent += Instance_playInfoChangeEvent;
    }

    private void Instance_playInfoChangeEvent(PlayInfoModel playInfo)
    {
        this.scoreText.text = playInfo.Score + "";
        this.floorText.text = playInfo.FloorCount + "F";
    }

}
