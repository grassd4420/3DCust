using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スライムの処理

public class Slime : MonoBehaviour
{
    public GameObject GameManager;
    public int SlHP = 6;　//スライムのＨＰ
    public GameObject damageEf;　//ダメージエフェクト
    private BoxCollider[] boxcol;　//ボックスコライダー用の配列
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        //３Ｄ時
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {


                boxcol[0].size = new Vector3(21f, 12f, 1f);
                boxcol[0].center = new Vector3(0, 0, 0);
                //boxcol[0].GetComponent<BoxCollider>().enabled = false;
                //boxcol[1].size = new Vector3(12.79f, 2.2f, 0.5f);
                //boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);


                //3ｄ空間では触れられないのでトリガーの当たり判定を消去
                boxcol[1].enabled = false;
            }

           

        }


        //２Ｄ時
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {

            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(18f, 12f, 30f);
                boxcol[0].center = new Vector3(0, 0, 0);
                boxcol[1].enabled = true;
                boxcol[1].size = new Vector3(12.79f, 2.2f, 30f);
                boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);
            }

        }
    }
    private void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag == "Player")
        {
            // 踏みつけると1ダメージ
            SlHP -= 1;
            
            //踏みつけた座標を取得
            Vector3 hitPos = col.ClosestPointOnBounds(this.transform.position);

            //エフェクトを呼び出し
            GameObject effect = Instantiate(damageEf) as GameObject;

            //踏みつけた座標からエフェクトを排出
            effect.transform.position = (Vector3)hitPos;
            
            //スライムのＨＰが０になれば破壊
            if (SlHP <= 0) Destroy(gameObject, 0.2f);


        }
       



    }
     

}
     
