using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script;
using UnityEngine.SceneManagement;

//�V�[���؂�ւ��X�N���v�g

public class Scenes2 : MonoBehaviour
{
    private float step2_time;    // �o�ߎ��ԃJ�E���g�p

    // Start is called before the first frame update
    void Start()
    {
        step2_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //5�b�o�߂�����X�y�[�X�������ăC���g�����X�L�b�v�\

        step2_time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && step2_time >= 5.0f)
        {
            FadeManager.Instance.LoadScene(SceneNames.Stage2, 1.0f);
        }

    }
}