using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�C�b�`�u���b�N�̏���

public class SwitchBlock : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private CameraShake shake; //�J������h�炷

    private const string PlayerTag = "Player";

    private BoxCollider[] boxcollider;//�{�b�N�X�R���C�_�[�p�̔z��

    //3d��ԓ��ł�Collider������
    private void Get3dCollider()
    {
        //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            //boxcollider[0]�g���K�[�p�R���C�_�[
            boxcollider[0].size = new Vector3(0.768f, 0.223f, 0.710f);
            boxcollider[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);

            //boxcollider[�P]�ڐG�p�R���C�_�[
            boxcollider[1].size = new Vector3(1, 1, 1);
            boxcollider[1].center = new Vector3(0.5f, 0.5f, -0.5f);
        }
    }
    //�Qd��ԓ��ł�Collider������
    private void Get2dCollider()
    {
        //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
        boxcollider = GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            //boxcollider[0]�g���K�[�p�R���C�_�[
            boxcollider[0].size = new Vector3(0.698f, 0.223f, 40f);
            boxcollider[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);
            //boxcollider[�P]�ڐG�p�R���C�_�[
            boxcollider[1].size = new Vector3(1, 1, 40);
            boxcollider[1].center = new Vector3(0.5f, 0.5f, -0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //3����
        if (gameManager.vi == true)
        {
            Get3dCollider();
        }

        //�Q����
        if (gameManager.vi == false)
        {
            Get2dCollider();
        }
    }
    private void OnTriggerEnter(Collider col)
    {

        //Player�̃^�O�̃I�u�W�F�N�g�ƐڐG�����ꍇ
        if (col.CompareTag(PlayerTag))
        {
            // �q���܂Ƃ߂ĉ�
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(gameObject, 0.2f);

            //�J������h�炷
            shake.Shake(0.25f, 0.1f);
        }
        
    }
}
