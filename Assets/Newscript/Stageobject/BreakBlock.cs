using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    private const string PlayerTag = "Player";

    private BoxCollider[] boxcollider;//�{�b�N�X�R���C�_�[�p�̔z��

    void Start()
    {
        gameManager = FindObjectOfType<DimentionSwitcher>();
    }

    //3d��ԓ��ł�Collider������
    private void Get3dCollider()
    {
        //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(1f, 1f, 1f);
            boxcollider[0].center = new Vector3(0, -0.1f, 0);
            boxcollider[1].size = new Vector3(1, 1, 1);

        }
    }

    //�Qd��ԓ��ł�Collider������
    private void Get2dCollider()
    {
        //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
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
        //�RD��
        if (gameManager.vi)
        {
            Get3dCollider();
        }
        //�QD��
        if (!gameManager.vi)
        {
            Get2dCollider();

        }
    }

    private void OnTriggerEnter(Collider col)
    {

        //Player�̃^�O�̃I�u�W�F�N�g�ƐڐG�����ꍇ
        if (col.CompareTag(PlayerTag))
        {
            Destroy(gameObject,0.1f);
        }
    }
}
