using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;
    public Text healthInfo;

    public void Update()
    {
        healthInfo.text = "health: " + health;
    }

    public void DoDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Died");
        SceneManager.LoadScene("GameOver");
    }
}
