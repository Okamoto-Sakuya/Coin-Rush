using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI参照")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;

    [Header("リザルトUI")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultCoinText;
    public TextMeshProUGUI resultRankText;

    [Header("制限時間設定")]
    public float gameTime = 40f;

    [Header("ランク設定")]
    public int rankB = 15;
    public int rankA = 30;
    public int rankS = 50;

    private float currentTime;
    private int coinCount;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentTime = gameTime;
        coinCount = 0;
        isGameOver = false;
        resultPanel.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        UpdateUI();

        if (currentTime <= 0f)
        {
            EndGame();
        }
    }

    void UpdateUI()
    {
        timerText.text = $"Time: {Mathf.Ceil(currentTime)}";
        coinText.text = $"Coin: {coinCount}";
    }

    public void AddCoin(int amount)
    {
        if (isGameOver) return;

        coinCount += amount;
        UpdateUI();
    }

    void EndGame()
    {
        isGameOver = true;

        // コイン出現停止
        var spawner = FindObjectOfType<CoinSpawner>();
        if (spawner) spawner.enabled = false;

        // リザルトUI表示
        resultPanel.SetActive(true);
        resultCoinText.text = $"コインの枚数: {coinCount}";

        // ランク判定＋色設定
        string rank = "C";
        Color rankColor = new Color(0.8f, 0.5f, 0.2f); // 銅色

        if (coinCount >= rankS)
        {
            rank = "S";
            rankColor = new Color(1.0f, 0.3f, 0.0f); // 赤＋オレンジ
        }
        else if (coinCount >= rankA)
        {
            rank = "A";
            rankColor = new Color(1.0f, 0.84f, 0.0f); // 金
        }
        else if (coinCount >= rankB)
        {
            rank = "B";
            rankColor = new Color(0.75f, 0.75f, 0.75f); // 銀
        }

        resultRankText.text = $"Rank: {rank}";
        resultRankText.color = rankColor;
    }

    //  タイトルボタンを押したときの処理
    public void OnTitleButton()
    {
        // 全てリセット
        currentTime = 0f;
        coinCount = 0;
        isGameOver = false;

        // 保存データなどをクリアしたい場合
        PlayerPrefs.DeleteAll();

        // タイトルシーンへ
        SceneManager.LoadScene("Title");
    }
    public void RemoveCoin(int amount)
    {
        coinCount -= amount;
        if (coinCount < 0)
            coinCount = 0; // マイナスにならない
        UpdateUI();
    }
}
