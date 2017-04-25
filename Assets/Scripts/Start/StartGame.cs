using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject NewGamePanel;

    [SerializeField]
    private GameObject LoadGamePanel;

    private bool _isLoading = false;


    public void OnNewGameBtnClick()
    {
        if (this._isLoading == true)
        {
            return;
        }
        this._isLoading = true;
        this.ChangeLoadPanel();
        StartCoroutine(this.OnLoadSuccess());
        print("start");
    }

    private void ChangeLoadPanel()
    {
        this.LoadGamePanel.SetActive(true);
        this.NewGamePanel.SetActive(false);
    }

    //加载成功回调函数
    public IEnumerator OnLoadSuccess()
    {
        //伪装加载
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameMain");
    }

    // Use this for initialization
    void Start()
    {
        this.LoadGamePanel.SetActive(false);
        this.NewGamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
