using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�C�b�`�u���b�N�̏���

public class SwitchBlock : MonoBehaviour
{
    public GameObject GameManager;
    public CameraShake shake;�@//�J������h�炷

    private BoxCollider[] boxcol;//�{�b�N�X�R���C�_�[�p�̔z��


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        //3����
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for(int i = 0; i < boxcol.Length; i++)
            {
                //boxcol[0]�g���K�[�p�R���C�_�[
                boxcol[0].size = new Vector3(0.768f, 0.223f, 0.710f);
                boxcol[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);

                //boxcol[�P]�ڐG�p�R���C�_�[
                boxcol[1].size = new Vector3(1, 1, 1);
                boxcol[1].center = new Vector3(0.5f, 0.5f, -0.5f);
            }

            
        }

        //�Q����
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            //�ڐG�p�ƃg���K�[�p�̃{�b�N�X�R���C�_�[���擾�@�z��Ɋi�[
            boxcol = GetComponents<BoxCollider>();
            for (int i = 0; i < boxcol.Length; i++)
            {
                //boxcol[0]�g���K�[�p�R���C�_�[
                boxcol[0].size = new Vector3(0.698f, 0.223f, 40f);
                boxcol[0].center = new Vector3(0.492118f, 0.932320f, -0.492629f);
                //boxcol[�P]�ڐG�p�R���C�_�[
                boxcol[1].size = new Vector3(1, 1, 40);
                boxcol[1].center = new Vector3(0.5f, 0.5f, -0.5f);
            }
            
        }
    }
    private void OnTriggerEnter(Collider col)
    {

        //Player�̃^�O�̃I�u�W�F�N�g�ƐڐG�����ꍇ
        if (col.gameObject.tag == "Player")
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
