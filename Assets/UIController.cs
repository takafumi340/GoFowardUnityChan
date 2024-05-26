using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //ゲームタイトルへ戻るボタン
    public GameObject gotoGameTitleButton;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 5f;

    //ゲームオーバーの判定
    private bool isGameOver = false;

    //Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");

        //ゲームタイトルへ戻るボタンを非表示
        gotoGameTitleButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGameOver == false)
        {
            //走った距離を更新する
            this.len += this.speed * Time.deltaTime;

            //走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }
    }

    public void GameOver()
    {
        this.isGameOver = true;

        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する
        this.gameOverText.GetComponent<Text>().text = "Game Over";

        //ゲームタイトルへ戻るボタンを表示
        gotoGameTitleButton.gameObject.SetActive(true);

        //ボタンを押したらGameTitle関数を実行する
        gotoGameTitleButton.GetComponent<Button>().onClick.AddListener(GameTitle); 
    }

    void GameTitle()
    {
        //ゲームタイトルシーンへ移動する
        SceneManager.LoadScene("GameTitleScene");
    }
}
