using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script;
using UnityEngine.SceneManagement;

//�V�[���؂�ւ��X�N���v�g

public class Scenes1 : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p
    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        step_time += Time.deltaTime;

        // 5�b��ɃC���g�����X�L�b�v�\
       
        
        if (Input.GetKeyDown(KeyCode.Space) && step_time >= 5.0f)
        {
            FadeManager.Instance.LoadScene(SceneNames.SampleScene, 1.0f);
        }
            
    }
}
