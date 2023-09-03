using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 导入Text所需的命名空间

public class RandomShakeText : MonoBehaviour
{
    public float shakeDistance = 1.0f; // 抖动的最大距离
    public float shakeSpeed = 1.0f;    // 抖动的速度

    // 随机种子
    public int randomSeed = 0;

    public Color startColor = Color.white; // 开始颜色
    public Color endColor = Color.red;     // 结束颜色

    private Vector3 originalPosition;
    private float startTime;
    private float randomOffset;

    private Text textComponent; // Text组件

    void Start()
    {
        originalPosition = transform.position;

        // 获取Text组件
        textComponent = GetComponent<Text>();
        if (textComponent != null)
        {
            // 初始化Text颜色为开始颜色
            textComponent.color = startColor;
        }

        startTime = Time.time + Random.Range(0, 10); // 在0到10秒之间开始抖动
    }

    void Update()
    {
        randomOffset = Random.Range(-2f,2f);

        // 使用随机种子来控制抖动
        float xOffset = Mathf.Sin((Time.time - startTime + randomSeed) * shakeSpeed) * shakeDistance + randomOffset;
        float yOffset = Mathf.Cos((Time.time - startTime + randomSeed) * shakeSpeed) * shakeDistance + randomOffset;

        // 应用抖动到Text的位置
        transform.position = originalPosition + new Vector3(xOffset, yOffset, 0);

        // 随机改变颜色
        if (textComponent != null)
        {
            textComponent.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time - startTime + randomSeed, 1f));
        }
    }
}
