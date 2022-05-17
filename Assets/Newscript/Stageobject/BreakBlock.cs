using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    private const string PlayerTag = "Player";

    private BoxCollider[] boxcollider;//ボックスコライダー用の配列

    void Start()
    {
        gameManager = FindObjectOfType<DimentionSwitcher>();
    }

    //3d空間内でのColliderを所得
    private void Get3dCollider()
    {
        //接触用とトリガー用のボックスコライダーを取得　配列に格納
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(1f, 1f, 1f);
            boxcollider[0].center = new Vector3(0, -0.1f, 0);
            boxcollider[1].size = new Vector3(1, 1, 1);

        }
    }

    //２d空間内でのColliderを所得
    private void Get2dCollider()
    {
        //接触用とトリガー用のボックスコライダーを取得　配列に格納
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(1f, 1f, 40f);
            boxcollider[0].center = new Vector3(0, -0.1f, 0);
            boxcollider[1].size = new Vector3(1, 1, 40);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //３D時
        if (gameManager.vi)
        {
            Get3dCollider();
        }
        //２D時
        if (!gameManager.vi)
        {
            Get2dCollider();

        }
    }

    private void OnTriggerEnter(Collider col)
    {

        //Playerのタグのオブジェクトと接触した場合
        if (col.CompareTag(PlayerTag))
        {
            Destroy(gameObject,0.1f);
        }
    }
}
