using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Enumを使う
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

    //アニメーターのパラメータのハッシュ
    private readonly int walkAnimationBoolHash = Animator.StringToHash("walkL");
    private readonly int changeViewPointAnimationTriggerHash = Animator.StringToHash("jigenn");
    private readonly int flyAnimationTriggerHash = Animator.StringToHash("fly");

    //タグ名の文字列
    private const string GroundTag = "Ground";
    private const string BarGroundTag = "BarGround";

    //入力検知の文字列
    private const string MoveHorizontalAxis = "Horizontal";
    private const string MoveVerticalAxis = "Vertical";
    private const string JumpKey = "space";

    private Rigidbody rb;
    private Animator anim = null;
    private bool isGround;

    //入力されている方向を管理するための配列
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

    //視点変更のアニメーションを実行する
    private void PlayChangeViewPointAnimation()
    {
        if (!Input.GetKeyDown(KeyCode.G)) return;

        anim.SetTrigger(changeViewPointAnimationTriggerHash);
        fp.Roling();
        img2.Roling();
        
    }

    //プレイヤーを回転させる
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

    //2D時のプレイヤー操作
    private void Controll2DPlayer()
    {
        Rotation_2D();
        SetMoveValue(true);
        Play2DWalkAnimation();
    }

    //3D時のプレイヤー操作
    private void Controll3DPlayer()
    {
        Rotation_3D();
        SetMoveValue(true);
        SetMoveValue(false);
        Play3DWalkAnimation();
    }

    //入力されている移動方向を登録する
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

    //2D時のプレイヤーの歩きアニメーションを実行する
    private void Play2DWalkAnimation()
    {
        float horizontalKey = Input.GetAxis(MoveHorizontalAxis);

        //キー入力がされていないならアニメーションを停止させる
        if (horizontalKey == 0)
        {
            anim.SetBool(walkAnimationBoolHash, false);
            return;
        }

        //アニメーションの向きを入力方向に合わせる
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

    //3D時のプレイヤーの歩きアニメーションを実行する
    private void Play3DWalkAnimation()
    {
        float horizontalKey = Input.GetAxis(MoveHorizontalAxis);
        float verticalKey = Input.GetAxis(MoveVerticalAxis);

        //キー入力がされていないならアニメーションを停止させる
        if (horizontalKey == 0 && verticalKey == 0)
        {
            anim.SetBool(walkAnimationBoolHash, false);
            return;
        }

        //アニメーションの向きを左右の入力方向に合わせる
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

    //ジャンプアニメーションの実行し速度を与える
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
    //登録されていた入力方向に対応する方向にプレイヤーを動かす
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

        //着地したときの処理
        if (otherObj.CompareTag(GroundTag) || otherObj.CompareTag(BarGroundTag))
        {
            isGround = true;
            anim.SetBool(flyAnimationTriggerHash, false);
        }
    }

    

}




