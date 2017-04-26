using UnityEngine;
using System.Collections;

/// <summary>
/// 怪物
/// </summary>
public class Monster : MonoBehaviour
{

    private Animator animator;
    private void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        this.animator.Play("Play");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
