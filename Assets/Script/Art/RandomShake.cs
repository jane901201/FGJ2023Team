using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShake : MonoBehaviour
{
    public float shakeDistance = 1.0f; // 抖動的最大距離
    public float shakeSpeed = 1.0f;    // 抖動的速度

    // 隨機種子
    public int randomSeed = 0;

    public Color startColor = Color.white; // 開始顏色
    public Color endColor = Color.red;     // 結束顏色

    private Vector3 originalPosition;
    private float startTime;
    private float randomOffset;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        originalPosition = transform.position;
        startTime = Time.time + Random.Range(0, 10); // 在0到10秒之間開始抖動

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // 初始化 SpriteRenderer 的顏色為開始顏色
            spriteRenderer.color = startColor;
        }
    }

    void Update()
    {
        randomOffset = Random.Range(-0.1f, 0.1f);

        // 使用隨機種子來控制抖動
        float xOffset = Mathf.Sin((Time.time - startTime + randomSeed) * shakeSpeed) * shakeDistance+ randomOffset;
        float zOffset = Mathf.Cos((Time.time - startTime + randomSeed) * shakeSpeed) * shakeDistance+ randomOffset;

        // 應用抖動到物體的位置
        transform.position = originalPosition + new Vector3(xOffset, 0, zOffset);

        // 隨機改變顏色
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time - startTime + randomSeed, 1f));
        }
    }
}
