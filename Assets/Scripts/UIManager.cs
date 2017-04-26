using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject GameOverPanel;

    [SerializeField]
    private GameObject PausePanel;

    [SerializeField]
    private GameObject PlayingPanel;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }
    }

    private Text scoreText, floorText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
        //初始化
        this._init();
    }

    private void Start()
    {
        this.BeginGameCb();
    }

    private void _init()
    {
        scoreText = PlayingPanel.transform.Find("ScoreText").GetComponent<Text>();
        floorText = PlayingPanel.transform.Find("FloorText").GetComponent<Text>();
    }

    //更新
    private void FixedUpdate()
    {
        this.scoreText.text = "Score:" + GameManager.Instance.playInfo.Score;
        this.floorText.text = "Floor:" + GameManager.Instance.playInfo.FloorCount;
    }

    //暂停游戏
    public void PauseGameCb()
    {
        this.GameOverPanel.SetActive(false);
        this.PausePanel.SetActive(true);
        this.PlayingPanel.SetActive(false);
    }

    //replay游戏
    public void RestartGameCb()
    {
        this.GameOverPanel.SetActive(false);
        this.PausePanel.SetActive(false);
        this.PlayingPanel.SetActive(true);
    }

    public void BeginGameCb()
    {
        this.GameOverPanel.SetActive(false);
        this.PausePanel.SetActive(false);
        this.PlayingPanel.SetActive(true);
    }

    #region ButtonsEvents

    //重新开始游戏
    public void OnReplayBtnClick()
    {
        //GameManager.Instance.R
        GameManager.Instance.ReplayGame();
    }

    public void OnPauseBtnClick()
    {
        this.PauseGameCb();
        //调用GameManager暂停游戏

        GameManager.Instance.PauseGame();
    }

    //播放按钮
    public void OnReBeginBtnClick()
    {
        this.BeginGameCb();
        GameManager.Instance.RePauseStartGame();
    }

    //回到start场景
    public void OnBackBtnClick()
    {
        SceneManager.LoadScene("Start");
    }

    //设置
    public void OnSettingBtnClick()
    {

    }
    #endregion

    internal void IncreaseScore(float v)
    {

    }
}
