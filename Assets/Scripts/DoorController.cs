using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorTransform; // �ŵ�Transform���
    public float openAngle = 90.0f; // �Ŵ�ʱ�ĽǶ�
    public float openSpeed = 2.0f; // �Ŵ򿪵��ٶ�

    private bool isOpening = false; // ���Ƿ����ڴ�

    void Update()
    {
        // ���������룬��������ض�������ʼ����
        if (Input.GetKeyDown(KeyCode.E) && !isOpening)
        {
            isOpening = true;
        }

        // ��������ڴ򿪣�������ת�ŵ����ŵĽǶ�
        if (isOpening)
        {
            float currentAngle = doorTransform.localEulerAngles.y;
            float desiredAngle = currentAngle + openSpeed * Time.deltaTime;
            if (desiredAngle > openAngle)
            {
                desiredAngle = openAngle;
                isOpening = false; // ���Ŵﵽָ���Ƕȣ�ֹͣ����
            }
            doorTransform.localEulerAngles = new Vector3(0, desiredAngle, 0);
        }
    }
}
