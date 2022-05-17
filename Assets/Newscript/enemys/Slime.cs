using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スライムの処理

public class Slime : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] public int SlHP = 6;　//スライムのＨＰ

    private const string PlayerTag = "Player";

    public GameObject damageEf;　//ダメージエフェクト
    private BoxCollider[] boxcollider; //ボックスコライダー用の配列

    private void Get3dCollider()
    {
        //接触用とトリガー用のボックスコライダーを取得　配列に格納
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(21f, 12f, 1f);
            boxcollider[0].center = new Vector3(0, 0, 0);

            //3ｄ空間では触れられないのでトリガーの当たり判定を消去
            boxcollider[1].enabled = false;
        }
    }

    private void Get2dCollider()
    {
        //接触用とトリガー用のボックスコライダーを取得　配列に格納
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(18f, 12f, 30f);
            boxcollider[0].center = new Vector3(0, 0, 0);
            boxcollider[1].enabled = true;
            boxcollider[1].size = new Vector3(12.79f, 2.2f, 30f);
            boxcollider[1].center = new Vector3(0.19f, 5.96f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //３Ｄ時
        if (gameManager.vi)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            Get3dCollider();
        }


        //２Ｄ時
        if (!gameManager.vi)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            Get2dCollider();
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(PlayerTag))
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
     
