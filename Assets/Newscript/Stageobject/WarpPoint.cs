using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���[�v���̏���

public class WarpPoint : MonoBehaviour
{
    private readonly int WarpPointTriggerHash = Animator.StringToHash("next");

    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private Vector3 pos;//���[�v��̍��W
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
        //�Q�����Ƀ��[�v���͈͓̔��Ƀv���C���[�����݂���ꍇ
        
        if(!gameManager.vi && other.CompareTag(PlayerTag))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetTrigger(WarpPointTriggerHash);
                //�ݒ肵�����W�Ƀe���|�[�g
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
        }

    }
}
