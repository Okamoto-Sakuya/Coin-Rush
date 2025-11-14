using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPTextFadeSimple : MonoBehaviour
{
    public TMP_Text tmpText;           // Inspectorでアサイン
    public float speed = 2f;      // 脈拍の速さ
    public float minAlpha = 0.3f; // 最小透明度
    public float maxAlpha = 1f;   // 最大透明度

    private void Update()
    {
        if (tmpText != null)
        {
            // Mathf.PingPongで0～1の間で往復する値を生成
            float t = Mathf.PingPong(Time.time * speed, 1f);
            // minAlpha～maxAlphaの範囲に変換
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);

            Color c = tmpText.color;
            c.a = alpha;
            tmpText.color = c;
        }
    }
}