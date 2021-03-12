using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerScript : MonoBehaviour
{
    public Vector2 targetPosition;
    float currentTime = 0f;
    float startingTime = 20f;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnGUI()
    {
        targetPosition = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Box(new Rect(targetPosition.x - 25, Screen.height - targetPosition.y - 150, 60, 20), currentTime.ToString("0"));
    }
}