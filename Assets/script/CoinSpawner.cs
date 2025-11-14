using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("コイン設定")]
    public GameObject coinPrefab;       // コインプレハブ
    public GameObject badItemPrefab;    // マイナスアイテムのプレハブ
    [Range(0f, 1f)]
    public float badItemChance = 0.2f;  // マイナスアイテムの出現確率（0?1）

    public float spawnInterval = 0.5f;  // 出現間隔
    public float itemSpeed = 200f;      // 落下速度（共通）

    [Header("出現範囲（座標指定）")]
    public float minX = -600f; // 左端
    public float maxX = 600f;  // 右端
    public float spawnY = 500f; // 出現高さ

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        // ランダムなX座標で出現
        float x = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(x, spawnY, 0f);

        // どっちを出すかを確率で決定
        GameObject prefabToSpawn = (Random.value < badItemChance) ? badItemPrefab : coinPrefab;

        // Canvas内に生成
        GameObject item = Instantiate(prefabToSpawn, transform.parent);
        RectTransform rect = item.GetComponent<RectTransform>();
        rect.anchoredPosition = spawnPos;

        // 落下速度設定（CoinController でも BadItemController でも共通で使える）
        var coinCtrl = item.GetComponent<CoinController>();
        if (coinCtrl != null) coinCtrl.fallSpeed = itemSpeed;

        var badCtrl = item.GetComponent<BadItemController>();
        if (badCtrl != null) badCtrl.fallSpeed = itemSpeed;
    }
}
