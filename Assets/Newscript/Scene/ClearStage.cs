using System.Collections;
using System.Collections.Generic;
using script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        // ‚Æ‚¢‚¤–¼‘O‚Ìƒ^ƒO‚ÆÚG‚µ‚½ê‡
        if (col.gameObject.tag == "Player")
        {
            FadeManager.Instance.LoadScene(SceneNames.StageClear, 0.3f);
        }
    }
}
