using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X���C���̏���

public class Slime : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] public int SlHP = 6;�@//�X���C���̂g�o

    private const string PlayerTag = "Player";

    public GameObject damageEf;�@//�_���[�W�G�t�F�N�g
    private BoxCollider[] boxcollider; //�{�b�N�X�R���C�_�[�p�̔z��

    private void Get3dCollider()
    {
        //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(21f, 12f, 1f);
            boxcollider[0].center = new Vector3(0, 0, 0);

            //3����Ԃł͐G����Ȃ��̂Ńg���K�[�̓����蔻�������
            boxcollider[1].enabled = false;
        }
    }

    private void Get2dCollider()
    {
        //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(18f, 12f, 30f);
            boxcollider[0].center = new Vector3(0, 0, 0);
            boxcollider[1].enabled = true;
            boxcollider[1].size = new Vector3(12.79f, 2.2f, 30f);
            boxcollider[1].center = new Vector3(0.19f, 5.96f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //�R�c��
        if (gameManager.vi)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            Get3dCollider();
        }


        //�Q�c��
        if (!gameManager.vi)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            Get2dCollider();
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(PlayerTag))
        {
            // ���݂����1�_���[�W
            SlHP -= 1;
            
            //���݂������W���擾
            Vector3 hitPos = col.ClosestPointOnBounds(this.transform.position);

            //�G�t�F�N�g���Ăяo��
            GameObject effect = Instantiate(damageEf) as GameObject;

            //���݂������W����G�t�F�N�g��r�o
            effect.transform.position = (Vector3)hitPos;
            
            //�X���C���̂g�o���O�ɂȂ�Δj��
            if (SlHP <= 0) Destroy(gameObject, 0.2f);

        }
    }
}
     
