using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ワープ扉の処理

public class WarpPoint : MonoBehaviour
{
    public Vector3 pos;//ワープ先の座標
    public GameObject GameManager;
    public GameObject sp1;
    private Animator anim = null;
    //Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        sp1 = GameObject.Find("sp1");
        anim = this.sp1.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other )
    {
        //２ｄ時にワープ扉の範囲内にプレイヤーが存在する場合
        
        if(GameManager.GetComponent<Switcher1>().vi == false && other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetTrigger("next");
                //設定した座標にテレポート
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
        }

        
       
        //other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
