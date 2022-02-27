using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//空間移動可能（Dimentex）スライムのスクリプト

public class DimentexSlime : MonoBehaviour
{
    public GameObject GameManager;
   
    public int SlHP = 6; //DimentexスライムのHP
    public GameObject damageEf;//ダメージエフェクト
    float minAngle = 0.0F;//回転用
    float maxAngle = 90.0F;//回転用
    private BoxCollider[] boxcol;//ボックスコライダー用の配列


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //３ｄ時
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(21f, 12f, 1f);
                boxcol[0].center = new Vector3(0, 0, 0);
                boxcol[1].size = new Vector3(12.79f, 2.2f, 0.5f);
                boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);
            }

            //回転させて3ｄ空間に反映
            float angle = Mathf.LerpAngle(minAngle, maxAngle, 1);
            transform.eulerAngles = new Vector3(0, angle, 0);

        }

        if (GameManager.GetComponent<Switcher1>().vi == false)
        {

            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(18f, 12f, 30f);
                boxcol[0].center = new Vector3(0, 0, 0);
                boxcol[1].size = new Vector3(12.79f, 2.2f, 30f);
                boxcol[1].center = new Vector3(0.19f, 5.96f, 0f);
            }


            //回転させて2ｄ空間に反映
            float angle = Mathf.LerpAngle(maxAngle, minAngle, 1);
            transform.eulerAngles = new Vector3(0, angle, 0);

        }
    }
    private void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag == "Player")
        {
            // j壊す
            SlHP -= 1;
            Vector3 hitPos = col.ClosestPointOnBounds(this.transform.position);
            GameObject effect = Instantiate(damageEf) as GameObject;
            effect.transform.position = (Vector3)hitPos;
            if (SlHP<=0)Destroy(gameObject, 0.2f);
            
        }
        // j壊す



    }
}
