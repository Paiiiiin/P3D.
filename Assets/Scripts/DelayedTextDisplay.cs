using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 引入TextMeshPro命名空间

public class DelayedTextDisplay : MonoBehaviour
{
    public TMP_Text targetText; // 在编辑器中设置这个变量，指向你的TMP_Text
    private float timer = 0.0f; // 计时器
    public float delayInSeconds = 120.0f; // 延迟时间，这里设置为60秒

    void Start()
    {
        targetText.enabled = false; // 开始时不显示文本
    }

    void Update()
    {
        timer += Time.deltaTime; // 更新经过的时间

        if (timer >= delayInSeconds) // 当计时器达到设定的延迟时间
        {
            targetText.enabled = true; // 使文本可见
            // 可选：在这里添加任何其他需要在文本显示时触发的逻辑
        }
    }
}


