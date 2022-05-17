using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スイッチブロックの処理

public class SwitchBlock : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private CameraShake shake; //カメラを揺らす

    private const string PlayerTag = "Player";

    private BoxCollider[] boxcollider;//ボックスコライダー用の配列

    //3d空間内でのColliderを所得
    private void Get3dCollider()
    {
        //接触用とトリガー用のボックスコライダーを取得　配列に格納
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            //boxcollider[0]トリガー用コライダー
            boxcollider[0].size = new Vector3(0.768f, 0.223f, 0.710f);
            boxcollider[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);

            //boxcollider[１]接触用コライダー
            boxcollider[1].size = new Vector3(1, 1, 1);
            boxcollider[1].center = new Vector3(0.5f, 0.5f, -0.5f);
        }
    }
    //２d空間内でのColliderを所得
    private void Get2dCollider()
    {
        //接触用とトリガー用のボックスコライダーを取得　配列に格納
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            //boxcollider[0]トリガー用コライダー
            boxcollider[0].size = new Vector3(0.698f, 0.223f, 40f);
            boxcollider[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);
            //boxcollider[１]接触用コライダー
            boxcollider[1].size = new Vector3(1, 1, 40);
            boxcollider[1].center = new Vector3(0.5f, 0.5f, -0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //3ｄ時
        if (gameManager.vi == true)
        {
            Get3dCollider();
        }

        //２ｄ時
        if (gameManager.vi == false)
        {
            Get2dCollider();
        }
    }
    private void OnTriggerEnter(Collider col)
    {

        //Playerのタグのオブジェクトと接触した場合
        if (col.CompareTag(PlayerTag))
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
