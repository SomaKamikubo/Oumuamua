using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

//プレイヤーの動きを実装するクラス
public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int WalkSpeed;
    [SerializeField] int DashSpeed;
    [SerializeField] int JumpForce;
    [SerializeField] bool isMoving;
    [SerializeField] bool isWalking;
    [SerializeField] bool isDashing;
    [SerializeField] bool isFalling;
    [SerializeField] bool isJumping;
    [SerializeField] bool isCrouching;
    int Speed;

    void Start()
    {
        Speed = 0;
    }

    void Update()
    {
        /*
        --------------
        毎フレーム実行
        --------------
        */
        //落下中かを判定
        isFalling = rb.velocity.y < -0.5f;

        //左右移動
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        //しゃがんでいるか
        //GetKeyを直接入れることでtrue,falseの切り替えが楽に。
        isCrouching = Input.GetKey(KeyCode.S);

        //動いているか
        isMoving = horizontal != 0;

        //スペースでジャンプ
        //ジャンプはここでいいのだろうか。。。
        //落下中ジャンプできるくね？
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping){
            Jump();
        }

        /*
        --------------------------------
        条件が合致した場合次のフレームへ
        --------------------------------
        */
        //動いていないならAnimationをIdleにする(init関数とかあるといいのか？)
        if (!isMoving){
            StopState();
            return;
        }

        //動いててかがんでるなら
        if (isCrouching){
            Sliding();
            return;
        }

        //↓以下、動いててかがんでない場合

        //SHIFTがおされたらダッシュするということのため
        isDashing = Input.GetKey(KeyCode.LeftShift);
        
        //DashしているならDashするって文としてなんかな、、、
        if (isDashing){
            DashState();
            return;
        }

        //ここまでくると動いててDashしてなくてかがんでいないため、歩きになる？
        isDashing = false;
        WalkState();
    }

    void StopState()
    {
        isWalking = false;
        isDashing = false;
    }

    void WalkState()
    {
        Speed = WalkSpeed;
        isWalking = true;
    }

    void DashState()
    {
        Speed = DashSpeed;
        isDashing = true;
    }

    void Sliding()
    {
        GetComponent<Animator>().SetTrigger("SlideTrigger");
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
            isFalling = false;
        }
    }


    public bool IsMoving { get { return isMoving; } }
    public bool IsWalking { get { return isWalking; } }
    public bool IsDashing { get { return isDashing; } }
    public bool IsJumping { get { return isJumping; } }
    public bool IsFalling { get { return isFalling; } }
    public bool IsCrouching { get { return isCrouching; } }
}
