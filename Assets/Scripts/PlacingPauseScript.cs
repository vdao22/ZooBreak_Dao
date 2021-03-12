using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingPauseScript : MonoBehaviour
{
    public GameObject GridLayout;
    public bool gameIsPausedDamage;
    public bool gameIsPausedSlow;

    // Start is called before the first frame update
    void Start()
    {
        GridLayout = GameObject.Find("GridLayout");
    }

    // Update is called once per frame
    void Update()
    {
        gameIsPausedDamage = GridLayout.GetComponent<GridScript>().placingProcedureDamage;
        gameIsPausedSlow = GridLayout.GetComponent<GridScript>().placingProcedureSlow;

        if (gameIsPausedSlow == true || gameIsPausedDamage == true)
        {
            Time.timeScale = 0;
        }    
        else
        {
            Time.timeScale = 1;
        }
    }
}
