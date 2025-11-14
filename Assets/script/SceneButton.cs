using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [Header("移動先のシーン名")]
    [Tooltip("ここに飛びたいシーン名を入力（例：Main、TitleSceneなど）")]
    public string targetSceneName;

    public void OnButtonClick()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            PlayerPrefs.DeleteAll();
            Time.timeScale = 1f;
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("? targetSceneName（シーン名）が設定されていません。");
        }
    }
}