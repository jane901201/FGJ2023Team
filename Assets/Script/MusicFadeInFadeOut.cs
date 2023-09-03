using UnityEngine;

public class MusicFadeInFadeOut : MonoBehaviour
{
    public float fadeInDuration = 3f; // 淡入持续时间
    public float fadeOutDuration = 3f; // 淡出持续时间
    public AudioSource audioSource;   // 音乐的 AudioSource 组件

    private float startVolume;        // 初始音量
    private float startTime;          // 启动时间
    private bool fadeInStarted = false;
    private bool fadeOutStarted = false;

    void Start()
    {
        // 获取初始音量
        startVolume = audioSource.volume;
        // 停止音乐播放，直到启动时间达到
        audioSource.Stop();
        // 获取当前时间
        startTime = Time.time;
    }

    void Update()
    {
        if (!fadeInStarted && Time.time - startTime >= fadeInDuration)
        {
            // 淡入开始
            audioSource.volume = 0f;
            audioSource.Play();
            fadeInStarted = true;
        }

        if (fadeInStarted)
        {
            // 计算淡入进度
            float progress = Mathf.Clamp01((Time.time - startTime) / fadeInDuration);
            // 将音量从0渐渐增加到初始音量
            audioSource.volume = Mathf.Lerp(0f, startVolume, progress);
        }

        if (fadeOutStarted)
        {
            // 计算淡出进度
            float progress = Mathf.Clamp01((Time.time - startTime) / fadeOutDuration);
            // 将音量从当前音量渐渐减小到0
            audioSource.volume = Mathf.Lerp(startVolume, 0f, progress);

            // 检查音量是否已经完全淡出
            if (progress >= 1f)
            {
                audioSource.Stop();
                fadeOutStarted = false;
            }
        }
    }

    // 淡出音乐的方法
    public void FadeOutMusic()
    {
        if (!fadeOutStarted)
        {
            // 记录淡出开始的时间
            startTime = Time.time;
            fadeOutStarted = true;
        }
    }
}
