using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//２ｄ、３ｄ空間の制限時間の処理 その他時間関係の処理

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private float countdown = 8f;//カウントダウン
    [SerializeField] private float dimentionRevival = 8f;//3D空間の制限時間及び再度使えるまでの時間
    [SerializeField] private float dimetionLimit = 0;//この数字以下になった場合に３D空間を終了

    private Animator anim = null;
    private readonly int changeViewPointAnimationTriggerHash = Animator.StringToHash("jigenn");

    public bool over = false;//３ｄ空間に制限時間以上入った場合のフラグ,DimentionSwitcherで使用
    public Image _3dGauage;//３ｄ空間ゲージ
    public Text timeText;//デバッグ用の時間表示
    
   
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.vi && countdown <= dimetionLimit)
        {
            timeText.text = "BAD";//デバッグ用の表示
            over = true;
            anim.SetTrigger(changeViewPointAnimationTriggerHash);
            //カウントダウンしない
            return;
        }

        if (!gameManager.vi && countdown >= dimentionRevival)
        {
            timeText.text = "MAX";//デバッグ用の表示
            over = false;
            //カウントダウンしない
            return;
        }

        //３ｄ時
        if (gameManager.vi)
        {
            //時間をカウントする
            countdown -= Time.deltaTime;
            //ゲージをへらす
            _3dGauage.fillAmount -= Time.deltaTime*0.13f;

            //時間を表示する
            timeText.text = countdown.ToString("f1") + "秒";

            //countdownが0以下になったとき
            if (countdown <= dimetionLimit)
            {
                //ゲージが溜まるまで空間切り替えが使えなくなる

                over = true;//DimentionSwitcherで使用
                timeText.text = "時間になりました！";
                return;
            }
        }

        //２ｄ時
        if (!gameManager.vi)
        {
            countdown += Time.deltaTime;
            //ゲージを増やす
            _3dGauage.fillAmount += Time.deltaTime*0.13f;

            //時間を表示する
            timeText.text = countdown.ToString("f1") + "秒";

            if (countdown >= dimentionRevival)
            {
                //ゲージが溜まったら空間切り替え使用可能
                over = false;// DimentionSwitcherで使用
                timeText.text = "時間になりました！";
                return;
                
            }
        }
    }
}