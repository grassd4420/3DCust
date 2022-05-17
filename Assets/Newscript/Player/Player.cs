using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Enum���g��
    private enum MoveVecEnum
    {
        Up,
        Down,
        Right,
        Left,
        Stop,
    }

    [SerializeField] private DimentionSwitcher gameManager;
    [SerializeField] private UIrot fp;
    [SerializeField] private UIrot img2;
    [SerializeField] private float jumpPower;

    private const float MoveUpValue = 0.12f;
    private const float MoveRightValue = 0.12f;
    private const float MinAngle = 0.0F;
    private const float MaxAngle = 90.0F;

    //�A�j���[�^�[�̃p�����[�^�̃n�b�V��
    private readonly int walkAnimationBoolHash = Animator.StringToHash("walkL");
    private readonly int changeViewPointAnimationTriggerHash = Animator.StringToHash("jigenn");
    private readonly int flyAnimationTriggerHash = Animator.StringToHash("fly");

    //�^�O���̕�����
    private const string GroundTag = "Ground";
    private const string BarGroundTag = "BarGround";

    //���͌��m�̕�����
    private const string MoveHorizontalAxis = "Horizontal";
    private const string MoveVerticalAxis = "Vertical";
    private const string JumpKey = "space";

    private Rigidbody rb;
    private Animator anim = null;
    private bool isGround;

    //���͂���Ă���������Ǘ����邽�߂̔z��
    Dictionary<MoveVecEnum, bool> moveDic = new Dictionary<MoveVecEnum, bool>
    {
        {MoveVecEnum.Up, false },
        {MoveVecEnum.Down, false },
        {MoveVecEnum.Right, false },
        {MoveVecEnum.Left, false },
        {MoveVecEnum.Stop,false },
    };

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayChangeViewPointAnimation();
        

        if (gameManager.vi == false)
        {
            Controll2DPlayer();
        }
        else
        {
            Controll3DPlayer();
        }

        if (isGround && Input.GetKeyDown(JumpKey))
        {
            Jump();
        }

        
    }

    //���_�ύX�̃A�j���[�V���������s����
    private void PlayChangeViewPointAnimation()
    {
        if (!Input.GetKeyDown(KeyCode.G)) return;

        anim.SetTrigger(changeViewPointAnimationTriggerHash);
        fp.Roling();
        img2.Roling();
        
    }

    //�v���C���[����]������
    private void Rotation_2D()
    {
        float angle = Mathf.LerpAngle(MaxAngle, MinAngle, 1);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
    private void Rotation_3D()
    {
        float angle = Mathf.LerpAngle(MinAngle, MaxAngle, 1);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    //2D���̃v���C���[����
    private void Controll2DPlayer()
    {
        Rotation_2D();
        SetMoveValue(true);
        Play2DWalkAnimation();
    }

    //3D���̃v���C���[����
    private void Controll3DPlayer()
    {
        Rotation_3D();
        SetMoveValue(true);
        SetMoveValue(false);
        Play3DWalkAnimation();
    }

    //���͂���Ă���ړ�������o�^����
    private void SetMoveValue(bool is2D)
    {
        if (is2D)
        {
            moveDic[MoveVecEnum.Up] = false;
            moveDic[MoveVecEnum.Down] = false;
            moveDic[MoveVecEnum.Right] = Input.GetKey(KeyCode.RightArrow);
            moveDic[MoveVecEnum.Left] = Input.GetKey(KeyCode.LeftArrow);
        }
        else
        {
            moveDic[MoveVecEnum.Up] = Input.GetKey(KeyCode.UpArrow);
            moveDic[MoveVecEnum.Down] = Input.GetKey(KeyCode.DownArrow);
            moveDic[MoveVecEnum.Right] = Input.GetKey(KeyCode.RightArrow);
            moveDic[MoveVecEnum.Left] = Input.GetKey(KeyCode.LeftArrow);
        }
    }

    //2D���̃v���C���[�̕����A�j���[�V���������s����
    private void Play2DWalkAnimation()
    {
        float horizontalKey = Input.GetAxis(MoveHorizontalAxis);

        //�L�[���͂�����Ă��Ȃ��Ȃ�A�j���[�V�������~������
        if (horizontalKey == 0)
        {
            anim.SetBool(walkAnimationBoolHash, false);
            return;
        }

        //�A�j���[�V�����̌�������͕����ɍ��킹��
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }
        else
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 1);
        }

        anim.SetBool(walkAnimationBoolHash, true);
    }

    //3D���̃v���C���[�̕����A�j���[�V���������s����
    private void Play3DWalkAnimation()
    {
        float horizontalKey = Input.GetAxis(MoveHorizontalAxis);
        float verticalKey = Input.GetAxis(MoveVerticalAxis);

        //�L�[���͂�����Ă��Ȃ��Ȃ�A�j���[�V�������~������
        if (horizontalKey == 0 && verticalKey == 0)
        {
            anim.SetBool(walkAnimationBoolHash, false);
            return;
        }

        //�A�j���[�V�����̌��������E�̓��͕����ɍ��킹��
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }

        else
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 1);
        }

        anim.SetBool(walkAnimationBoolHash, true);
    }

    //�W�����v�A�j���[�V�����̎��s�����x��^����
    private void Jump()
    {
        isGround = false;
        anim.SetBool(flyAnimationTriggerHash, true);
        rb.velocity = Vector3.up * jumpPower;
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    //�o�^����Ă������͕����ɑΉ���������Ƀv���C���[�𓮂���
    private void MovePlayer()
    {
        if (moveDic[MoveVecEnum.Up])
        {
            transform.Translate(0f, 0f, MoveUpValue);
        }

        if (moveDic[MoveVecEnum.Down])
        {
            transform.Translate(0f, 0f, -MoveUpValue);
        }

        if (moveDic[MoveVecEnum.Right])
        {
            transform.Translate(MoveRightValue, 0f, 0f);
        }

        if (moveDic[MoveVecEnum.Left])
        {
            transform.Translate(-MoveRightValue, 0f, 0f);
        }

        if (moveDic[MoveVecEnum.Stop])
        {
            transform.Translate(0f, 0f, 0f);
        }
    }
   
    void OnCollisionEnter(Collision other)
    {
        var otherObj = other.gameObject;

        //���n�����Ƃ��̏���
        if (otherObj.CompareTag(GroundTag) || otherObj.CompareTag(BarGroundTag))
        {
            isGround = true;
            anim.SetBool(flyAnimationTriggerHash, false);
        }
    }

    

}




