using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//�z�肵�Ă����ȊO�̏ꏊ�ɗ������ꍇ�̏���

public class Out : MonoBehaviour
{
    private const string PlayerTag = "Player";
    
    // �iOut�j�ڐG�����ꍇ
    private void OnTriggerEnter(Collider col)
    {
        // Player�Ƃ������O�̃^�O�ƐڐG�����ꍇ
        if (col.CompareTag(PlayerTag))
        {
            // ����Scene��������x�ǂݍ���
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
        }
    }
}
