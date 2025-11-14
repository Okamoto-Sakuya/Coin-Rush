using UnityEngine;

public class BadItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.RemoveCoin(1); // コインを減らす
            Destroy(gameObject); // アイテムを消す
        }
        else if (collision.CompareTag("Ground")) // 画面下などに落ちたら削除
        {
            Destroy(gameObject);
        }
    }
}
