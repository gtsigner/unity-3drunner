using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region fields
    private int _score = 0;
    private int _floorCount = 1;
    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
        }
    }
    public int FloorCount
    {
        get
        {
            return _floorCount;
        }

        set
        {
            _floorCount = value;
        }
    }
    #endregion

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


    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    protected GameManager()
    {
        GameState = GameState.Start;
        CanSwipe = false;
    }

    public GameState GameState { get; set; }

    public bool CanSwipe { get; set; }


    //重新开始游戏
    public void ReplayGame()
    {
        SceneManager.LoadScene("GameMain");
        this.RestoreTotal();
    }

    public void PlayerDie()
    {
        //UIManager.Instance.SetStatus(Constants.StatusDeadTapToStart);
        //this.GameState = GameState.Dead; 
    }

    //重置
    private void RestoreTotal()
    {
        this._score = 0;
        this._floorCount = 1;
    }

}



