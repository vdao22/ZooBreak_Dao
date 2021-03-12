using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP: " + health;

        if (health <= 0)
        {
            SoundManagerScript.PlaySound("GameOver");
            SceneManager.LoadScene("GameOver");
        }
    }
}
