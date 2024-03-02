using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //オーディオソースのコンポーネントを入れる
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //オーディオソースのコンポーネントを取得する
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //キューブが地面に衝突した場合、もしくはキューブ同士で衝突した場合に効果音を鳴らす
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground" || collision.gameObject.name == "CubePrefab(Clone)")
        {
            audioSource.Play();
        }
    }
}
