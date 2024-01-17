using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorTransform; // 门的Transform组件
    public float openAngle = 90.0f; // 门打开时的角度
    public float openSpeed = 2.0f; // 门打开的速度

    private bool isOpening = false; // 门是否正在打开

    void Update()
    {
        // 检测玩家输入，如果按下特定键，则开始开门
        if (Input.GetKeyDown(KeyCode.E) && !isOpening)
        {
            isOpening = true;
        }

        // 如果门正在打开，则逐渐旋转门到开门的角度
        if (isOpening)
        {
            float currentAngle = doorTransform.localEulerAngles.y;
            float desiredAngle = currentAngle + openSpeed * Time.deltaTime;
            if (desiredAngle > openAngle)
            {
                desiredAngle = openAngle;
                isOpening = false; // 当门达到指定角度，停止开门
            }
            doorTransform.localEulerAngles = new Vector3(0, desiredAngle, 0);
        }
    }
}
