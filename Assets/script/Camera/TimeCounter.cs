using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�Q���A�R����Ԃ̐������Ԃ̏��� ���̑����Ԋ֌W�̏���

public class TimeCounter : MonoBehaviour
{
    
    public bool over = false;//�R����Ԃɐ������Ԉȏ�������ꍇ�̃t���O�@//Switcher1�Ŏg�p
    public Image image;//�R����ԃQ�[�W
    public float timeLimit = 5.0f;//�^�C�����~�b�g
    public Text timeText;//���Ԃ�\������Text�^�̕ϐ�
    public GameObject GameManager;
    private Animator anim = null;//�A�j���[�V�����փA�N�Z�X

    //�J�E���g�_�E��
    public float countdown = 10.0f;

    

    //�|�[�Y���Ă��邩�ǂ���
    private bool isPose = false;

    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("GameManager");
        
        
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        //�N���b�N���ꂽ�Ƃ�
        if (Input.GetMouseButtonDown(0))
        {
            //�|�[�Y���ɃN���b�N���ꂽ�Ƃ�
            if (isPose)
            {
                //�|�[�Y��Ԃ���������
                isPose = false;
            }
            //�i�s���ɃN���b�N���ꂽ�Ƃ�
            else
            {
                //�|�[�Y��Ԃɂ���
                isPose = true;
            }
        }

        //
        if (GameManager.GetComponent<Switcher1>().vi == true&& countdown <= 0)
        {
            //
            timeText.text = "BAD";
            over = true;
            anim.SetTrigger("jigenn");
            //�J�E���g�_�E�����Ȃ�
            return;
        }

        if (GameManager.GetComponent<Switcher1>().vi == false && countdown >= 8)
        {
            //
            timeText.text = "MAX";
            over = false;

            //�J�E���g�_�E�����Ȃ�
            return;
        }

        //�R����
        if (GameManager.GetComponent<Switcher1>().vi == true)
        {
            //���Ԃ��J�E���g����
            countdown -= Time.deltaTime;
            //�Q�[�W���ւ炷
            image.fillAmount -= Time.deltaTime*0.13f;

            //���Ԃ�\������
            timeText.text = countdown.ToString("f1") + "�b";

            //countdown��0�ȉ��ɂȂ����Ƃ�
            if (countdown <= 0)
            {
                //�Q�[�W�����܂�܂ŋ�Ԑ؂�ւ����g���Ȃ��Ȃ�

                over = true;//Switcher1�Ŏg�p
                timeText.text = "���ԂɂȂ�܂����I";
                return;
                

            }
        }

        //�Q����
        if (GameManager.GetComponent<Switcher1>().vi == false)
        {

            countdown += Time.deltaTime;
            //�Q�[�W�𑝂₷
            image.fillAmount += Time.deltaTime*0.13f;

            //���Ԃ�\������
            timeText.text = countdown.ToString("f1") + "�b";


            if (countdown >= 10)
            {
                //�Q�[�W�����܂������Ԑ؂�ւ��g�p�\
                over = false;//Switcher1�Ŏg�p
                timeText.text = "���ԂɂȂ�܂����I";
                return;
                
            }
        }


    }
}