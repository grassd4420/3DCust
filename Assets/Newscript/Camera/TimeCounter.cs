using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�Q���A�R����Ԃ̐������Ԃ̏��� ���̑����Ԋ֌W�̏���

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private float countdown = 8f;//�J�E���g�_�E��
    [SerializeField] private float dimentionRevival = 8f;//3D��Ԃ̐������ԋy�эēx�g����܂ł̎���
    [SerializeField] private float dimetionLimit = 0;//���̐����ȉ��ɂȂ����ꍇ�ɂRD��Ԃ��I��

    private Animator anim = null;
    private readonly int changeViewPointAnimationTriggerHash = Animator.StringToHash("jigenn");

    public bool over = false;//�R����Ԃɐ������Ԉȏ�������ꍇ�̃t���O,DimentionSwitcher�Ŏg�p
    public Image _3dGauage;//�R����ԃQ�[�W
    public Text timeText;//�f�o�b�O�p�̎��ԕ\��
    
   
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.vi && countdown <= dimetionLimit)
        {
            timeText.text = "BAD";//�f�o�b�O�p�̕\��
            over = true;
            anim.SetTrigger(changeViewPointAnimationTriggerHash);
            //�J�E���g�_�E�����Ȃ�
            return;
        }

        if (!gameManager.vi && countdown >= dimentionRevival)
        {
            timeText.text = "MAX";//�f�o�b�O�p�̕\��
            over = false;
            //�J�E���g�_�E�����Ȃ�
            return;
        }

        //�R����
        if (gameManager.vi)
        {
            //���Ԃ��J�E���g����
            countdown -= Time.deltaTime;
            //�Q�[�W���ւ炷
            _3dGauage.fillAmount -= Time.deltaTime*0.13f;

            //���Ԃ�\������
            timeText.text = countdown.ToString("f1") + "�b";

            //countdown��0�ȉ��ɂȂ����Ƃ�
            if (countdown <= dimetionLimit)
            {
                //�Q�[�W�����܂�܂ŋ�Ԑ؂�ւ����g���Ȃ��Ȃ�

                over = true;//DimentionSwitcher�Ŏg�p
                timeText.text = "���ԂɂȂ�܂����I";
                return;
            }
        }

        //�Q����
        if (!gameManager.vi)
        {
            countdown += Time.deltaTime;
            //�Q�[�W�𑝂₷
            _3dGauage.fillAmount += Time.deltaTime*0.13f;

            //���Ԃ�\������
            timeText.text = countdown.ToString("f1") + "�b";

            if (countdown >= dimentionRevival)
            {
                //�Q�[�W�����܂������Ԑ؂�ւ��g�p�\
                over = false;// DimentionSwitcher�Ŏg�p
                timeText.text = "���ԂɂȂ�܂����I";
                return;
                
            }
        }
    }
}