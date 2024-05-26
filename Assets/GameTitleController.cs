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
        //ボタンを押したらStartGame関数を実行する
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        //メインゲームシーンへ移動する
        SceneManager.LoadScene("MainGameScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
