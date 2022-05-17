using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ワープ扉の処理

public class WarpPoint : MonoBehaviour
{
    private readonly int WarpPointTriggerHash = Animator.StringToHash("next");

    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private Vector3 pos;//ワープ先の座標
    [SerializeField] private GameObject sp1;//SpinUi

    private const string PlayerTag = "Player";
    private Animator anim = null;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.sp1.GetComponent<Animator>();
    }

    
    void OnTriggerStay(Collider other )
    {
        //２ｄ時にワープ扉の範囲内にプレイヤーが存在する場合
        
        if(!gameManager.vi && other.CompareTag(PlayerTag))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetTrigger(WarpPointTriggerHash);
                //設定した座標にテレポート
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
        }

    }
}
