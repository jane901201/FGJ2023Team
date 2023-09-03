using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Events;
using UnityEngine.UI; // 导入UI命名空间

public class DelayedEventTrigger : MonoBehaviour
{
    [Serializable]
    public class CustomUnityEvent : UnityEvent { }

    public CustomUnityEvent customEvent; // 自定义的UnityEvent
    public float delaySeconds = 2f; // 自定义的等待秒数
    public Text countdownText; // 用于显示倒计时的Text组件
    [SerializeField] string countDownPrefixTxt = "Bug CountDown: ";

    private bool isEventTriggered = false;
    private float countdownTime;

    public void StartCountDown()
    {
        countdownTime = delaySeconds;

        // 更新UI显示
        UpdateCountdownText();

        // 在指定秒数后触发UnityEvent
        InvokeRepeating("UpdateCountdown", 0.2f, 0.2f);
    }

    private void UpdateCountdown()
    {
        countdownTime -= 0.2f;

        // 更新UI显示
        UpdateCountdownText();

        if (countdownTime <= 0 && !isEventTriggered)
        {
            customEvent.Invoke();
            isEventTriggered = true;
        }
    }

    private void UpdateCountdownText()
    {
        if (countdownText != null)
        {
            countdownText.text = countDownPrefixTxt + Mathf.Ceil(countdownTime).ToString();
        }
    }
}

