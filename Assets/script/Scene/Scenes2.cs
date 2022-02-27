using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーン切り替えスクリプト

public class Scenes2 : MonoBehaviour
{
    private float step2_time;    // 経過時間カウント用

    // Start is called before the first frame update
    void Start()
    {
        step2_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //5秒経過したらスペースを押してイントロをスキップ可能

        step2_time += Time.deltaTime;

        if (Input.GetKeyDown("space") && step2_time >= 5.0f)
        {
            FadeManager.Instance.LoadScene("Stage2", 1.0f);
            //SceneManager.LoadScene("Stage2");
        }

    }
}