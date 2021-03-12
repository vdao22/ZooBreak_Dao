using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public TextMeshProUGUI waveText;
    public bool[] wave;
    public GameObject spawnPoint;
    public GameObject Grid;
    public int timer;
    public bool coroutineStarted;
    public bool stop;


    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
        stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPoint = Grid.GetComponent<GridScript>().paths[0];

        waveText.text = "WAVE TIMER: " + timer + "s";

        if (!PauseMenuScript.isPaused)
        {
            if (coroutineStarted == false)
            {
                StartCoroutine(Second());
                coroutineStarted = true;
            }

            if (timer <= 0)
            {
                if (stop == true)
                {
                    timer = 30;
                    stop = false;
                    CalculateWave();
                }
                else
                {
                    timer = 10;
                    stop = true;
                }
            }
        }
    }

    public void CalculateWave()
    {
        if (stop == false && wave[0] == false && wave[1] == false && wave[2] == false)
        {
            wave[0] = true;
        }
        else if (stop == false && wave[0] == true && wave[1] == false && wave[2] == false)
        {
            wave[1] = true;
        }
        else if (stop == false && wave[0] == true && wave[1] == true && wave[2] == false)
        {
            wave[2] = true;
        }
        else if (stop == false && wave[0] == true && wave[1] == true && wave[2] == true)
        {
            wave[0] = false;
            wave[1] = false;
            wave[2] = false;
            CalculateWave();
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);
        timer--;
        coroutineStarted = false;

        if (stop == false && wave[0] == true && wave[1] == false && wave[2] == false)
        {
            Instantiate(Enemy1, spawnPoint.transform.position, Quaternion.identity);
        }
        if (stop == false && wave[0] == true && wave[1] == true && wave[2] == false)
        {
            Instantiate(Enemy2, spawnPoint.transform.position, Quaternion.identity);
        }
        if (stop == false && wave[0] == true && wave[1] == true && wave[2] == true)
        {
            Instantiate(Enemy3, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
