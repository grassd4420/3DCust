using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�]�����ė����Q���̓����蔻��̏���

public class CircleObjectColliderSwitcher : MonoBehaviour
{
    private DimentionSwitcher switcher;

    // Start is called before the first frame update
    void Start()
    {
        switcher = FindObjectOfType<DimentionSwitcher>();
    }

    //3d��ԓ��ł�Collider������
    private void Get3dCollider()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<MeshCollider>().enabled = true;
    }

    //�Qd��ԓ��ł�Collider������
    private void Get2dCollider()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<MeshCollider>().enabled = false;
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.height = 60;
    }
    

    // Update is called once per frame
    void Update()
    {
        //��Ԃɉ����Đ؂�ւ�

        //3����
        if(switcher.vi )
        {
            Get3dCollider();
        }

        //�Q����
        if (switcher.vi == false)
        {
            Get2dCollider();
        }
    }
}
