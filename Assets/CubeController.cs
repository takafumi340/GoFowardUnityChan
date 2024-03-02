using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // �L���[�u�̈ړ����x
    private float speed = -12;

    // ���ňʒu
    private float deadLine = -10;

    //�I�[�f�B�I�\�[�X�̃R���|�[�l���g������
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //�I�[�f�B�I�\�[�X�̃R���|�[�l���g���擾����
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //�L���[�u���n�ʂɏՓ˂����ꍇ�A�������̓L���[�u���m�ŏՓ˂����ꍇ�Ɍ��ʉ���炷
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground" || collision.gameObject.name == "CubePrefab(Clone)")
        {
            audioSource.Play();
        }
    }
}
