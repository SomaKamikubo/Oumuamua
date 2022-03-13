using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

//�v���C���[�̓�������������N���X
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
        ���t���[�����s
        --------------
        */
        //���������𔻒�
        isFalling = rb.velocity.y < -0.5f;

        //���E�ړ�
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        //���Ⴊ��ł��邩
        //GetKey�𒼐ړ���邱�Ƃ�true,false�̐؂�ւ����y�ɁB
        isCrouching = Input.GetKey(KeyCode.S);

        //�����Ă��邩
        isMoving = horizontal != 0;

        //�X�y�[�X�ŃW�����v
        //�W�����v�͂����ł����̂��낤���B�B�B
        //�������W�����v�ł��邭�ˁH
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping){
            Jump();
        }

        /*
        --------------------------------
        ���������v�����ꍇ���̃t���[����
        --------------------------------
        */
        //�����Ă��Ȃ��Ȃ�Animation��Idle�ɂ���(init�֐��Ƃ�����Ƃ����̂��H)
        if (!isMoving){
            StopState();
            return;
        }

        //�����ĂĂ�����ł�Ȃ�
        if (isCrouching){
            Sliding();
            return;
        }

        //���ȉ��A�����ĂĂ�����łȂ��ꍇ

        //SHIFT�������ꂽ��_�b�V������Ƃ������Ƃ̂���
        isDashing = Input.GetKey(KeyCode.LeftShift);
        
        //Dash���Ă���Ȃ�Dash������ĕ��Ƃ��ĂȂ񂩂ȁA�A�A
        if (isDashing){
            DashState();
            return;
        }

        //�����܂ł���Ɠ����Ă�Dash���ĂȂ��Ă�����ł��Ȃ����߁A�����ɂȂ�H
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
