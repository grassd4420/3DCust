using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スイッチブロックの処理

public class SwitchBlock : MonoBehaviour
{
    public GameObject GameManager;
    public CameraShake shake;　//カメラを揺らす

    private BoxCollider[] boxcol;//ボックスコライダー用の配列


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        //3ｄ時
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for(int i = 0; i < boxcol.Length; i++)
            {
                //boxcol[0]トリガー用コライダー
                boxcol[0].size = new Vector3(0.768f, 0.223f, 0.710f);
                boxcol[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);

                //boxcol[１]接触用コライダー
                boxcol[1].size = new Vector3(1, 1, 1);
                boxcol[1].center = new Vector3(0.5f, 0.5f, -0.5f);
            }

            
        }

        //２ｄ時
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            //接触用とトリガー用のボックスコライダーを取得　配列に格納
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                //boxcol[0]トリガー用コライダー
                boxcol[0].size = new Vector3(0.698f, 0.223f, 40f);
                boxcol[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);
                //boxcol[１]接触用コライダー
                boxcol[1].size = new Vector3(1, 1, 40);
                boxcol[1].center = new Vector3(0.5f, 0.5f, -0.5f);
            }
            
        }
    }
    private void OnTriggerEnter(Collider col)
    {

        //Playerのタグのオブジェクトと接触した場合
        if (col.gameObject.tag == "Player")
        {
            // 子もまとめて壊す
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(gameObject, 0.2f);

            //カメラを揺らす
            shake.Shake(0.25f, 0.1f);
        }
            
        

        
    }
}
