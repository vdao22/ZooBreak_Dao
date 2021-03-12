using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemiesLeftScript : MonoBehaviour
{
    public TextMeshProUGUI enemiesLeftText;
    public static int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = 90;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesLeftText.text = "ENEMIES LEFT: " + enemiesLeft;

        if (enemiesLeft <= 0)
        {
            SoundManagerScript.PlaySound("Victory SoundFX4");
            SceneManager.LoadScene("Victory");
        }
    }
}
