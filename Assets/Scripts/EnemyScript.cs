using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float x, y, z;
    public int stage;
    public float startSpeed;
    public float speed;
    public Vector3 stageBegin;
    public Vector3 stageEnd;
    public GameObject Grid;
    public GameObject thisGameObject;

    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        z = 5;
        transform.position = new Vector3(x, y, z);

        stage = 0;
        stageBegin = transform.position;
        Grid = GameObject.Find("GridLayout");
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            if (stage < 15)
            {
                goToNextStage(stage);
            }

            stageBegin = transform.position;
            transform.position = Vector3.MoveTowards(stageBegin, stageEnd, speed * Time.deltaTime);

            if (stageBegin == stageEnd)
            {
                stage++;
            }

            if (stage == 15) // last stage
            {
                stageEnd.z += 5;
                stage = 100;
            }

            if (stage == 101 && stageBegin == stageEnd)
            {
                EnemiesLeftScript.enemiesLeft--;
                SoundManagerScript.PlaySound("playertakedmg");
                HealthScript.health--;
                Destroy(thisGameObject);
            }
        }
    }

    public void goToNextStage(int i)
    {
        stageEnd = Grid.GetComponent<GridScript>().paths[i].transform.position;
        stageEnd.y = 0;
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
}
