using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���[�v���̏���

public class WarpPoint : MonoBehaviour
{
    public Vector3 pos;//���[�v��̍��W
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
        //�Q�����Ƀ��[�v���͈͓̔��Ƀv���C���[�����݂���ꍇ
        
        if(GameManager.GetComponent<Switcher1>().vi == false && other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetTrigger("next");
                //�ݒ肵�����W�Ƀe���|�[�g
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
        }

        
       
        //other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
