using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region 
    public PlayInfoModel playInfo;
    public delegate void PlayInfoChangeEvent(PlayInfoModel playInfo);

    internal void UpFloor()
    {
        this.playInfo.FloorCount++;
        //增加速度
        this.playInfo.MoveSpeed += 20f;


    }

    public event PlayInfoChangeEvent playInfoChangeEvent;

    private GameState gameState = GameState.Start;

    #endregion
    public GameState GameState
    {
        get
        {
            return gameState;
        }

        set
        {
            gameState = value;
        }
    }

    //5s 跑5m
    private float scoreUpSpeed = 2f;

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
    }

    private void Start()
    {
        this.RestoreTotal();
    }

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    protected GameManager()
    {
        GameState = GameState.Start;
        CanSwipe = false;
    }



    public bool CanSwipe { get; set; }


    //用户得分
    private void Update()
    {
        scoreUpSpeed -= Time.deltaTime;
        if (this.scoreUpSpeed <= 0)
        {
            playInfo.Score++;
            scoreUpSpeed = 2f;
            //通知
            if (this.playInfoChangeEvent != null)
            {
                this.playInfoChangeEvent(this.playInfo);
            }
        }

    }

    //重新开始游戏
    public void ReplayGame()
    {
        SceneManager.LoadScene("GameMain");
        this.RestoreTotal();
    }

    public void PlayerDie()
    {


    }

    //重置
    private void RestoreTotal()
    {
        this.playInfo = new PlayInfoModel();
        this.playInfo.MoveSpeed = 200;
        this.playInfo.Score = 0;
        this.playInfo.FloorCount = 1;
        this.playInfoChangeEvent(this.playInfo);
    }

    internal void PauseGame()
    {
        Time.timeScale = 0;
    }
    internal void RePauseStartGame()
    {
        Time.timeScale = 1;
    }
}



