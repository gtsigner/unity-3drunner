using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartBgAnim : MonoBehaviour
{

    public Sprite[] mySprites;
    Image myImage;
    int index = 0;
    float waitTime = 0f;
    public float PlaySpeed = 5f;
    public bool IsLoop = true;

    void Start()
    {
        myImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame  
    void Update()
    {
        if (waitTime <= 0)
        {
            ChangeImage();
            waitTime = 5f;
        }
        waitTime -= (PlaySpeed * Time.deltaTime);
    }

    void ChangeImage()
    {
        index++;
        if (index < mySprites.Length)
        {
            myImage.sprite = mySprites[index];
        }
        else if (this.IsLoop)
        {
            index = 0;
        }
    }
}
