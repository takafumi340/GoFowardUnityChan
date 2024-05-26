using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTitleUnityChan : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;

    // �n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߂���
        this.animator.SetFloat("Horizontal", 1);

        // ���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
    }
}
