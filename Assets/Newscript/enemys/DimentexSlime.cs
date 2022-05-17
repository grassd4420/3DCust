using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//空間移動可能（Dimentex）スライムのスクリプト

public class DimentexSlime : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private int SlHP = 6; //DimentexスライムのHP

    private const string PlayerTag = "Player";

    public GameObject damageEf;//ダメージエフェクト
    float minAngle = 0.0F;//回転用
    float maxAngle = 90.0F;//回転用
    private BoxCollider[] boxcollider;//ボックスコライダー用の配列


    private void Get3dCollider()
    {
        //接触用とトリガー用のボックスコライダーを取得　配列に格納
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(21f, 12f, 1f);
            boxcollider[0].center = new Vector3(0, 0, 0);
            boxcollider[1].size = new Vector3(12.79f, 2.2f, 0.5f);
            boxcollider[1].center = new Vector3(0.19f, 5.96f, 0f);
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
            boxcollider[1].size = new Vector3(12.79f, 2.2f, 30f);
            boxcollider[1].center = new Vector3(0.19f, 5.96f, 0f);
        }
    }

    private void Rotation_3D()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, 1);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    private void Rotation_2D()
    {
        float angle = Mathf.LerpAngle(maxAngle, minAngle, 1);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        //３ｄ時
        if (gameManager.vi)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            Get3dCollider();

            //回転させて3ｄ空間に反映
            Rotation_3D();

        }

        if (!gameManager.vi)
        {

            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            Get2dCollider();


            //回転させて2ｄ空間に反映
            Rotation_2D();

        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(PlayerTag))
        {
            SlHP -= 1;
            Vector3 hitPos = col.ClosestPointOnBounds(this.transform.position);
            GameObject effect = Instantiate(damageEf) as GameObject;
            effect.transform.position = (Vector3)hitPos;
            if (SlHP<=0)Destroy(gameObject, 0.2f);
        }
    }
}
