using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ԉړ��\�iDimentex�j�X���C���̃X�N���v�g

public class DimentexSlime : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private int SlHP = 6; //Dimentex�X���C����HP

    private const string PlayerTag = "Player";

    public GameObject damageEf;//�_���[�W�G�t�F�N�g
    float minAngle = 0.0F;//��]�p
    float maxAngle = 90.0F;//��]�p
    private BoxCollider[] boxcollider;//�{�b�N�X�R���C�_�[�p�̔z��


    private void Get3dCollider()
    {
        //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[0].size = new Vector3(21f, 12f, 1f);
            boxcollider[0].center = new Vector3(0, 0, 0);
            boxcollider[1].size = new Vector3(12.79f, 2.2f, 0.5f);
            boxcollider[1].center = new Vector3(0.19f, 5.96f, 0f);
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
            boxcollider[1].size = new Vector3(12.79f, 2.2f, 30f);
            boxcollider[1].center = new Vector3(0.19f, 5.96f, 0f);
        }
    }

    private void Rotation_3D()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, 1);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    private void Rotation_2D()
    {
        float angle = Mathf.LerpAngle(maxAngle, minAngle, 1);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        //�R����
        if (gameManager.vi)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            Get3dCollider();

            //��]������3����Ԃɔ��f
            Rotation_3D();

        }

        if (!gameManager.vi)
        {

            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            Get2dCollider();


            //��]������2����Ԃɔ��f
            Rotation_2D();

        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(PlayerTag))
        {
            SlHP -= 1;
            Vector3 hitPos = col.ClosestPointOnBounds(this.transform.position);
            GameObject effect = Instantiate(damageEf) as GameObject;
            effect.transform.position = (Vector3)hitPos;
            if (SlHP<=0)Destroy(gameObject, 0.2f);
        }
    }
}
