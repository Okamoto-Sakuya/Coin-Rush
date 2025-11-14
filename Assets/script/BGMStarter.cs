using UnityEngine;
using System.Collections;

public class BGMStarter : MonoBehaviour
{
    [Header("BGMÄ¶‚Ü‚Å‚Ì’x‰„•b”")]
    public float delay = 4f;

    void Start()
    {
        StartCoroutine(DelayedBGM(delay));
    }

    IEnumerator DelayedBGM(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopBGM();           // ‚Ü‚¸’â~
            AudioManager.instance.PlayBGM(true);       // ‹­§Ä¶
        }
    }


}
