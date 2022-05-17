using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//想定していた以外の場所に落ちた場合の処理

public class Out : MonoBehaviour
{
    private const string PlayerTag = "Player";
    
    // （Out）接触した場合
    private void OnTriggerEnter(Collider col)
    {
        // Playerという名前のタグと接触した場合
        if (col.CompareTag(PlayerTag))
        {
            // 今のSceneをもう一度読み込む
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
        }
    }
}
