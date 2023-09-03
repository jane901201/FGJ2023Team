using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomShake : MonoBehaviour
{
    public float shakeDistance = 1.0f; // 抖动的最大距离
    public float shakeSpeed = 1.0f;    // 抖动的速度
    public float shakeAmplitude = 0.1f;

    // 随机种子
    public int randomSeed = 0;

    public Color startColor = Color.white; // 开始颜色
    public Color endColor = Color.red;     // 结束颜色

    public bool shakeX = true; // 是否抖动X轴
    public bool shakeY = true; // 是否抖动Y轴
    public bool shakeZ = true; // 是否抖动Z轴

    private Vector3 originalPosition;
    private float startTime;
    private float randomOffset;

    private SpriteRenderer spriteRenderer;
    private Image image;

    void Start()
    {
        originalPosition = transform.position;
        startTime = Time.time + Random.Range(0, 10); // 在0到10秒之间开始抖动

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // 初始化 SpriteRenderer 的颜色为开始颜色
            spriteRenderer.color = startColor;
        }

        image = GetComponent<Image>();
        if (image != null)
        {
            image.color = startColor;
        }
    }

    void Update()
    {
        randomOffset = Random.Range(-shakeAmplitude, shakeAmplitude);

        // 使用随机种子来控制抖动
        float xOffset = 0f, yOffset = 0f, zOffset = 0f;

        if (shakeX)
        {
            xOffset = Mathf.Sin((Time.time - startTime + randomSeed) * shakeSpeed) * shakeDistance + randomOffset;
        }

        if (shakeY)
        {
            yOffset = Mathf.Sin((Time.time - startTime + randomSeed) * shakeSpeed) * shakeDistance + randomOffset;
        }

        if (shakeZ)
        {
            zOffset = Mathf.Sin((Time.time - startTime + randomSeed) * shakeSpeed) * shakeDistance + randomOffset;
        }

        // 应用抖动到物体的位置
        transform.position = originalPosition + new Vector3(xOffset, yOffset, zOffset);

        // 随机改变颜色
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time - startTime + randomSeed, 1f));
        }

        if (image != null)
        {
            image.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time - startTime + randomSeed, 1f));
        }
    }
}
