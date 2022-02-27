using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//２ｄ、３ｄ空間の制限時間の処理 その他時間関係の処理

public class TimeCounter : MonoBehaviour
{
    
    public bool over = false;//３ｄ空間に制限時間以上入った場合のフラグ　//Switcher1で使用
    public Image image;//３ｄ空間ゲージ
    public float timeLimit = 5.0f;//タイムリミット
    public Text timeText;//時間を表示するText型の変数
    public GameObject GameManager;
    private Animator anim = null;//アニメーションへアクセス

    //カウントダウン
    public float countdown = 10.0f;

    

    //ポーズしているかどうか
    private bool isPose = false;

    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("GameManager");
        
        
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        //クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            //ポーズ中にクリックされたとき
            if (isPose)
            {
                //ポーズ状態を解除する
                isPose = false;
            }
            //進行中にクリックされたとき
            else
            {
                //ポーズ状態にする
                isPose = true;
            }
        }

        //
        if (GameManager.GetComponent<Switcher1>().vi == true&& countdown <= 0)
        {
            //
            timeText.text = "BAD";
            over = true;
            anim.SetTrigger("jigenn");
            //カウントダウンしない
            return;
        }

        if (GameManager.GetComponent<Switcher1>().vi == false && countdown >= 8)
        {
            //
            timeText.text = "MAX";
            over = false;

            //カウントダウンしない
            return;
        }

        //３ｄ時
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //時間をカウントする
            countdown -= Time.deltaTime;
            //ゲージをへらす
            image.fillAmount -= Time.deltaTime*0.13f;

            //時間を表示する
            timeText.text = countdown.ToString("f1") + "秒";

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                //ゲージが溜まるまで空間切り替えが使えなくなる

                over = true;//Switcher1で使用
                timeText.text = "時間になりました！";
                return;
                

            }
        }

        //２ｄ時
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {

            countdown += Time.deltaTime;
            //ゲージを増やす
            image.fillAmount += Time.deltaTime*0.13f;

            //時間を表示する
            timeText.text = countdown.ToString("f1") + "秒";


            if (countdown >= 10)
            {
                //ゲージが溜まったら空間切り替え使用可能
                over = false;//Switcher1で使用
                timeText.text = "時間になりました！";
                return;
                
            }
        }


    }
}