using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//�z�肵�Ă����ȊO�̏ꏊ�ɗ������ꍇ�̏���

public class Out : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // �iOut�j�ڐG�����ꍇ
    private void OnTriggerEnter(Collider col)
    {
        // Player�Ƃ������O�̃^�O�ƐڐG�����ꍇ
        if (col.gameObject.tag == "Player")
        {
            // ����Scene��������x�ǂݍ���
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
        }
    }
}
