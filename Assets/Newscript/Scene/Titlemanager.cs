using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script;
using UnityEngine.SceneManagement;

//タイトル画面のスクリプト

public class Titlemanager : MonoBehaviour
{
    
    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene(SceneNames.StageSelect, 0.5f);
    }
    
}
