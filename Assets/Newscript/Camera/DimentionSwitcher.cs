using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//�Q����3���̋�Ԃ�؂�ւ���X�N���v�g
public class DimentionSwitcher : MonoBehaviour
{
    [SerializeField] private TimeCounter GameObject;
    

    
    public GameObject mainCam;//�Q���J����
    public GameObject subCam;//3���J����
    public bool overtime = false;//��Ԑ؂�ւ��\������

    public bool vi = false; //��Ԑ؂�ւ�����

    //////  vi false   2d  /////
    //////  vi true    3d  /////

    //////  overtime false ��Ԑ؂�ւ��\   /////
    //////  overtime true  ��Ԑ؂�ւ��s��  /////


 


    // Start is called before the first frame update

    void Start()
    {

        mainCam.SetActive(true);
        subCam.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        //��Ԑ؂�ւ��\�ȏꍇ
        if(overtime == false)
        {
            //�f�L�[�������Ƌ�Ԑ؂�ւ�
            if (Input.GetKeyDown(KeyCode.G))
            {
                mainCam.SetActive(!mainCam.activeSelf);
                subCam.SetActive(!subCam.activeSelf);

                vi = !vi;
            }
        }

        //�������Ԉȏ�R����Ԃɋ���Ƌ�Ԑ؂�ւ��s��

        //TimeCounter��over���Q��
        if (GameObject.over == true)
        {
           
            if (!overtime)
            {

                overtime = true;
                //�����I�ɐ؂�ւ�
                mainCam.SetActive(!mainCam.activeSelf);
                subCam.SetActive(!subCam.activeSelf);
                vi = !vi;
            }

        }

        //��Ԑ؂�ւ��s������

        //TimeCounter��over���Q��
        if (GameObject.over == false)
        {
            overtime = false;
        }

    }
    
}
