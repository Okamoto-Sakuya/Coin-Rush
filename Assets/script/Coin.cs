using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Header("落下速度（UI基準）")]
    public float fallSpeed = 200f; // インスペクターで調整可

    void Update()
    {
        // 下方向へ移動
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // 画面外に出たら削除
        if (transform.localPosition.y < -800f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddCoin(1);

            // ?? コインの効果音を再生（←これを追加）
            AudioManager.instance.PlayCoinSound();

            Destroy(gameObject);
        }
    }
}
