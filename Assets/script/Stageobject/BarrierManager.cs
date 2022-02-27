using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//空間切り替えで乗れる足場が変わる処理

public class BarrierManager : MonoBehaviour
{
    public GameObject GameManager;
    GameObject[] barri_Objects;//２ｄ壁
    GameObject[] barg_Objects;//２ｄ床
    public bool playerIN;

    // Start is called before the first frame update
    void Start()
    {

        //Barri tagのオブジェクトを格納
        barri_Objects = GameObject.FindGameObjectsWithTag("Barri");

        for (int i = 0; i < barri_Objects.Length; i++)
        {
            //コライダーを消す
            Debug.Log(barri_Objects[i]);
        }

        //BarGround tagのオブジェクトを格納
        barg_Objects = GameObject.FindGameObjectsWithTag("BarGround");

        for (int i = 0; i < barg_Objects.Length; i++)
        {
            //コライダーを消す
            Debug.Log(barg_Objects[i]);
        }
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        //2D時
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            //Barri tagのオブジェクトを順番に呼び出し
            for (int i = 0; i < barri_Objects.Length; i++)
            {
                //コライダーをオン
                if (playerIN == false)
                {
                    barri_Objects[i].GetComponent<BoxCollider>().enabled = true;
                }
                
            }

            //BarGround tagのオブジェクトを順番に呼び出し
            for (int i = 0; i < barg_Objects.Length; i++)
            {
                //コライダーをオン
                if (playerIN == false)
                {
                    barg_Objects[i].GetComponent<BoxCollider>().enabled = true;
                }
                
            }

        }

        //３D時
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {

            //Barri tagのオブジェクトを順番に呼び出し
            for (int i = 0; i < barri_Objects.Length; i++)
            {
                //コライダーを消す
                barri_Objects[i].GetComponent<BoxCollider>().enabled = false;
            }

            //BarGround tagのオブジェクトを順番に呼び出し
            for (int i = 0; i < barg_Objects.Length; i++)
            {
                //コライダーを消す
                barg_Objects[i].GetComponent<BoxCollider>().enabled = false;
            }

        }
    }
    private void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            playerIN = true;
        }
        else playerIN = false;
    }
}
