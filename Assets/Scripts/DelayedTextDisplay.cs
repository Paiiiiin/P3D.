using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ����TextMeshPro�����ռ�

public class DelayedTextDisplay : MonoBehaviour
{
    public TMP_Text targetText; // �ڱ༭�����������������ָ�����TMP_Text
    private float timer = 0.0f; // ��ʱ��
    public float delayInSeconds = 120.0f; // �ӳ�ʱ�䣬��������Ϊ60��

    void Start()
    {
        targetText.enabled = false; // ��ʼʱ����ʾ�ı�
    }

    void Update()
    {
        timer += Time.deltaTime; // ���¾�����ʱ��

        if (timer >= delayInSeconds) // ����ʱ���ﵽ�趨���ӳ�ʱ��
        {
            targetText.enabled = true; // ʹ�ı��ɼ�
            // ��ѡ������������κ�������Ҫ���ı���ʾʱ�������߼�
        }
    }
}


