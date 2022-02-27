using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject fp;
    public GameObject img2;

    float up = 0.1f;
    float right = 0.1f;
    float minAngle = 0.0F;//回転用
    float maxAngle = 90.0F;//回転用

    private Rigidbody rb; //リジッドボディを取得するための変数
    public float jumpPower; //上方向にかける力
    private bool isGround; //着地しているかどうかの判定
    private Animator anim = null;



    //移動
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"up", false },
        {"down", false },
        {"right", false },
        {"left", false },
        {"stop",false },
    };

    

    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        fp = GameObject.Find("fp");
        img2 = GameObject.Find("Image2");


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            //視点切り替えアニメーション
            anim.SetTrigger("jigenn");
            fp.GetComponent<UIrot>().roling();
            img2.GetComponent<UIrot>().roling();

        }


        //  vi == false   2d
        //  vi == true    3d



        //2D

        if (GameManager.GetComponent<Switcher1>().vi == false)
        {
            //anim.SetBool("g", true);
            //anim.SetBool("g", false);
            //transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));

            

            //プレイヤー回転
            float angle = Mathf.LerpAngle(maxAngle, minAngle, 1);
            transform.eulerAngles = new Vector3(0, angle, 0);


            //移動2ｄ
            move["down"] = false;
            move["up"] = false;
            move["right"] = Input.GetKey(KeyCode.RightArrow);
            move["left"] = Input.GetKey(KeyCode.LeftArrow);
            float horizontalKey = Input.GetAxis("Horizontal");
            
            if (horizontalKey > 0)
            {
                //歩きアニメーション
                transform.localScale = new Vector3(0.1f, 0.1f, 1);
                anim.SetBool("walkL", true);
            }

            else if (horizontalKey < 0)
            {
                //反転
                transform.localScale = new Vector3(-0.1f, 0.1f, 1);
                anim.SetBool("walkL", true);
            }

            else
            {
                anim.SetBool("walkL", false);
            }
           

        }

        //3D

        if (GameManager.GetComponent<Switcher1>().vi == true)
        {

            //anim.SetBool("g", true);
            //anim.SetBool("g", false);
            // move["right"] = Input.GetKey(KeyCode.UpArrow);
            //move["left"] = Input.GetKey(KeyCode.DownArrow);


            

            //プレイヤー回転
            float angle = Mathf.LerpAngle(minAngle, maxAngle, 1);
            transform.eulerAngles = new Vector3(0, angle, 0);

            //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));

            //移動３ｄ
            move["down"] = Input.GetKey(KeyCode.DownArrow);
            move["up"] = Input.GetKey(KeyCode.UpArrow);
            move["right"] = Input.GetKey(KeyCode.RightArrow);
            move["left"] = Input.GetKey(KeyCode.LeftArrow);

            float horizontalKey = Input.GetAxis("Horizontal");
            float verticalKey = Input.GetAxis("Vertical");
            
            if (horizontalKey > 0)
            {
                //歩きアニメーション
                transform.localScale = new Vector3(0.1f, 0.1f, 1);
                anim.SetBool("walkL", true);
            }

            else if (horizontalKey < 0)
            {
                //歩きアニメーション反転
                transform.localScale = new Vector3(-0.1f, 0.1f, 1);
                anim.SetBool("walkL", true);
            }

            else if (verticalKey > 0)
            {
                //歩きアニメーション
                //transform.localScale = new Vector3(0.1f, 0.1f, 1);
                anim.SetBool("walkL", true);
            }

            else if (verticalKey < 0)
            {
                //歩きアニメーション
                //transform.localScale = new Vector3(-0.1f, 0.1f, 1);
                anim.SetBool("walkL", true);
            }

            else
            {
                anim.SetBool("walkL", false);
            }
            
        }

        if (isGround == true)//着地しているとき
        {

            if (Input.GetKeyDown("space"))
            {
                isGround = false;//  isGroundをfalseにする
                anim.SetBool("fly", true);//jump ani
                //anim.SetBool("walkL", false);
                rb.velocity = Vector3.up * jumpPower; //上に向かって力を加える
            }

        }
        


    }
    void FixedUpdate()
    {


        if (move["up"])
        {
            transform.Translate(0f, 0f, up);

        }

        if (move["down"])
        {
            transform.Translate(0f, 0f, -up);

        }

        if (move["right"])
        {
            transform.Translate(right, 0f, 0f);

        }

        if (move["left"])
        {
            transform.Translate(-right, 0f, 0f);

        }

        if (move["stop"])
        {
            transform.Translate(0f, 0f, 0f);

        }

    }


    void OnCollisionEnter(Collision other) //地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground") //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
            anim.SetBool("fly", false);// jump ani
        }
        if (other.gameObject.tag == "BarGround") //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
            anim.SetBool("fly", false);// jump ani
        }
    }

}    
       
        
    


