using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SafePointHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Slider healthSlider; // ������ʹ��Slider��ΪѪ��

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
    }

    private void Die()
    {
        // �����㱻�ݻٵ��߼������粥�Ŵݻٶ�������Ϸʧ�ܵ�
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}