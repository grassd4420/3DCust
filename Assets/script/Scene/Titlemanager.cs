using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//タイトル画面のスクリプト

public class Titlemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene("StageSelect", 0.5f);
        //SceneManager.LoadScene("StageSelect");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
