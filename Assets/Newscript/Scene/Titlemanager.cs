using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script;
using UnityEngine.SceneManagement;

//�^�C�g����ʂ̃X�N���v�g

public class Titlemanager : MonoBehaviour
{
    
    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene(SceneNames.StageSelect, 0.5f);
    }
    
}
