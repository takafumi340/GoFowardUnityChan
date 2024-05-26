using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;

�@�@//Unity�������ړ�������R���|�[�l���g������
  �@Rigidbody2D rigid2D;

    //�n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    //�W�����v�̑��x�̌���
    private float dump = 0.8f;

    //�W�����v�̑��x
    float jumpVelocity = 20;

    //�Q�[���I�[�o�[�ɂȂ�ʒu
    private float deadLine = -9;

    //�������̈ړ��͈͂̍ŏ��l
    [SerializeField]private float minX = -10f;

    //�E�����̈ړ��͈͂̍ő�l
    [SerializeField] private float maxX = -2f;

    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�^�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();

        //Rigidbody2D�̃R���|�[�l���g���擾����
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߂���
        this.animator.SetFloat("Horizontal", 1);

        //���n���Ă��邩�ǂ������ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //�W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //���n��ԂŃN���b�N���ꂽ�ꍇ
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //������̗͂�������
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //�N���b�N����߂��������ւ̑��x����������
        if (Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //�E�����ւ̈ړ�
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 pos = transform.position;
            pos.x += 0.008f;
            transform.position = pos;
        }
        //�������ւ̈ړ�
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 pos = transform.position;
            pos.x -= 0.008f;
            transform.position = pos;
        }

        //�������̈ړ��͈͐���
        if (transform.position.x < minX)
        {
            Vector3 range = transform.position;
            range.x = minX;
            transform.position = range;
        }
        //�E�����̈ړ��͈͐���
        else if (transform.position.x > maxX)
        {
            Vector3 range = transform.position;
            range.x = maxX;
            transform.position = range;
        }

        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���
        if (transform.position.x < this.deadLine)
        {
            //UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƁuGoToGameTitle�v��\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //���j�e�B������j������
            Destroy(gameObject);
        }
    }
}
