using System.Collections;
using System.Collections.Generic;
using script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        // �Ƃ������O�̃^�O�ƐڐG�����ꍇ
        if (col.gameObject.tag == "Player")
        {
            FadeManager.Instance.LoadScene(SceneNames.StageClear, 0.3f);
        }
    }
}
