using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTitleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�{�^������������StartGame�֐������s����
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        //���C���Q�[���V�[���ֈړ�����
        SceneManager.LoadScene("MainGameScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
