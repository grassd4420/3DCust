using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script;
using UnityEngine.SceneManagement;

//シーン切り替えスクリプト

public class Scenes1 : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用
    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        step_time += Time.deltaTime;

        // 5秒後にイントロをスキップ可能
       
        
        if (Input.GetKeyDown(KeyCode.Space) && step_time >= 5.0f)
        {
            FadeManager.Instance.LoadScene(SceneNames.SampleScene, 1.0f);
        }
            
    }
}
