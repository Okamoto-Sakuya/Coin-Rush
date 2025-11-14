using UnityEngine;

public class BadItemController : MonoBehaviour
{
    public float fallSpeed = 200f;
    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 下に落下
        rect.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime;

        // 画面外に出たら削除
        if (rect.anchoredPosition.y < -600f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.RemoveCoin(1);

            // ?? マイナスアイテムの効果音を再生（←これを追加）
            AudioManager.instance.PlayBadItemSound();

            Destroy(gameObject);
        }
    }
}
