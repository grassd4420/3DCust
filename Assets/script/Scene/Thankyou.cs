using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Thankyou : MonoBehaviour
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
        if (Input.GetKeyDown("space") && step_time >= 2.0f)
        {
            SceneManager.LoadScene("title");
        }
    }
}
