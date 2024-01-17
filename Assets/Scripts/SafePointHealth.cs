using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SafePointHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Slider healthSlider; // 假设你使用Slider作为血条

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
        // 保护点被摧毁的逻辑，比如播放摧毁动画，游戏失败等
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}