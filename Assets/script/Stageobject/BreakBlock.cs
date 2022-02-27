using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    public GameObject GameManager;
    private BoxCollider[] boxcol;//ボックスコライダー用の配列

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //３D時
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(1f, 1f, 1f);
                boxcol[0].center = new Vector3(0, -0.1f, 0);
                boxcol[1].size = new Vector3(1, 1, 1);
                
            }


        }
        //２D時
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                boxcol[0].size = new Vector3(1f, 1f, 40f);
                boxcol[0].center = new Vector3(0, -0.1f, 0);
                boxcol[1].size = new Vector3(1, 1, 40);
                
            }

        }
    }
    private void OnTriggerEnter(Collider col)
    {

        //Playerのタグのオブジェクトと接触した場合
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject,0.1f);
        }
        // j壊す



    }
}
