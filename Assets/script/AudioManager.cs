using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("BGM")]
    public AudioSource bgmSource;
    public AudioClip mainBGM;

    [Header("効果音")]
    public AudioSource sfxSource;
    public AudioClip coinSE;
    public AudioClip badItemSE;

    void Awake()
    {
        // 既に別のAudioManagerが存在する場合は自分を消す
        if (instance == null)
        {
            instance = this;                // 自分をinstanceに設定
            DontDestroyOnLoad(gameObject);  // シーン切り替えでも消さない
        }
        else if (instance != this)
        {
            Destroy(gameObject);            // 重複したAudioManagerを削除
            return;
        }
    }



    public void PlayCoinSound()
    {
        sfxSource.PlayOneShot(coinSE, 0.5f); // ← 第二引数が音量（0～1）
    }

    public void PlayBadItemSound()
    {
        sfxSource.PlayOneShot(badItemSE, 0.5f);
    }

    public void PlayBGM(bool forceRestart = false)
    {
        if (bgmSource.clip == null && mainBGM != null)
            bgmSource.clip = mainBGM;

        if (forceRestart || !bgmSource.isPlaying)
            bgmSource.Play();
    }


    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // AudioManager.cs の中に追加
    public void SetBGMVolume(float vol)
    {
        bgmSource.volume = Mathf.Clamp01(vol); //  修正
    }


}
