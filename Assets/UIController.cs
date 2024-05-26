using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //�Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;

    //���s�����e�L�X�g
    private GameObject runLengthText;

    //�Q�[���^�C�g���֖߂�{�^��
    public GameObject gotoGameTitleButton;

    //����������
    private float len = 0;

    //���鑬�x
    private float speed = 5f;

    //�Q�[���I�[�o�[�̔���
    private bool isGameOver = false;

    //Start is called before the first frame update
    void Start()
    {
        //�V�[���r���[����I�u�W�F�N�g�̎��̂���������
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");

        //�Q�[���^�C�g���֖߂�{�^�����\��
        gotoGameTitleButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGameOver == false)
        {
            //�������������X�V����
            this.len += this.speed * Time.deltaTime;

            //������������\������
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }
    }

    public void GameOver()
    {
        this.isGameOver = true;

        //�Q�[���I�[�o�[�ɂȂ����Ƃ��ɁA��ʏ�ɃQ�[���I�[�o�[��\������
        this.gameOverText.GetComponent<Text>().text = "Game Over";

        //�Q�[���^�C�g���֖߂�{�^����\��
        gotoGameTitleButton.gameObject.SetActive(true);

        //�{�^������������GameTitle�֐������s����
        gotoGameTitleButton.GetComponent<Button>().onClick.AddListener(GameTitle); 
    }

    void GameTitle()
    {
        //�Q�[���^�C�g���V�[���ֈړ�����
        SceneManager.LoadScene("GameTitleScene");
    }
}
