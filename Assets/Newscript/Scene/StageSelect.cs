using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script;
using UnityEngine.SceneManagement;


//ステージセレクトシーンの処理

public class StageSelect : MonoBehaviour
{
    private const string Stage1Tag = "Stage1";
    private const string Stage2Tag = "Stage2";
    private const string PlayerTag = "Player";
    private const string ThankStageTag = "Thank";

    [SerializeField] private DimentionSwitcher gameManager;

    void OnTriggerStay(Collider other)
    {
        //２ｄ時にワープ扉の範囲内にプレイヤーが存在する場合
        if (gameManager.vi == false && other.CompareTag(PlayerTag) && this.CompareTag(Stage1Tag))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                
                FadeManager.Instance.LoadScene(SceneNames.intro1, 0.3f);
                
            }
        }

        //２ｄ時にワープ扉の範囲内にプレイヤーが存在する場合
        if (gameManager.vi == false && other.CompareTag(PlayerTag) && this.CompareTag(Stage2Tag))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
               
                FadeManager.Instance.LoadScene(SceneNames.intro2, 0.3f);
                
            }
        }

        //２ｄ時にワープ扉の範囲内にプレイヤーが存在する場合
        if (gameManager.vi == false && other.CompareTag(PlayerTag) && this.CompareTag(ThankStageTag))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
               
                FadeManager.Instance.LoadScene(SceneNames.Thankyou, 0.3f);
                
            }
        }

    }


    
   
}
