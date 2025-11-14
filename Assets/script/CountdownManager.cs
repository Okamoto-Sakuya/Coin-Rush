using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
    [Header("参照")]
    public TextMeshProUGUI countdownText;   // 数字カウント用
    public TextMeshProUGUI subText;         // 下の補助テキスト用
    public GameObject coinSpawner;
    public GameObject badItemSpawner;
    public GameObject player;

    [Header("カウント設定")]
    public float countdownTime = 3f;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        // ゲーム開始前は停止
        coinSpawner.SetActive(false);
        badItemSpawner.SetActive(false);
        player.SetActive(false);
        GameManager.instance.enabled = false;

        // カウント中はサブテキストを表示
        subText.gameObject.SetActive(true);
        subText.text = "コインだけ集めろ！"; // ←ここは好きなメッセージに変えられる！

        float time = countdownTime;
        while (time > 0)
        {
            countdownText.text = Mathf.Ceil(time).ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }

        // 「START!」に変更
        countdownText.text = "START!";
        subText.text = ""; // ←スタート時の下テキスト

        yield return new WaitForSeconds(1f);

        // テキストを非表示にしてゲーム開始
        countdownText.gameObject.SetActive(false);
        subText.gameObject.SetActive(false);

        coinSpawner.SetActive(true);
        badItemSpawner.SetActive(true);
        player.SetActive(true);
        GameManager.instance.enabled = true;
    }
}
