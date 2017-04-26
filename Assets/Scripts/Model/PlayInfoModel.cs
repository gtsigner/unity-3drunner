using UnityEngine;
using System.Collections;

public class PlayInfoModel
{
    private string username;
    private string uuid;
    private int score;
    private int floorCount;
    private int createTime;
    private float moveSpeed;

    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            username = value;
        }
    }

    public string Uuid
    {
        get
        {
            return uuid;
        }

        set
        {
            uuid = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public int FloorCount
    {
        get
        {
            return floorCount;
        }

        set
        {
            floorCount = value;
        }
    }

    public int CreateTime
    {
        get
        {
            return createTime;
        }

        set
        {
            createTime = value;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }
}