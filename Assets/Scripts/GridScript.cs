using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GridScript : MonoBehaviour
{
    public GameObject ground;
    public int columnLength;
    public int rowLength;
    public float x_Space;
    public float z_Space;
    public GameObject path;
    public GameObject[] panels;
    public GameObject[] paths;
    public GameObject DamageTower;
    public GameObject SlowTower;
    public GameObject placingText;
    public GameObject DamageButton;
    public GameObject SlowButton;

    public bool placingProcedureDamage;
    public bool placingProcedureSlow;
    private Ray ray;
    private RaycastHit hit;
    public GameObject hitted;
    public int money;
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(ground, new Vector3(x_Space + (x_Space * (i % columnLength)), 0, z_Space + (z_Space * (i / columnLength))), Quaternion.identity);
        }

        CreatePath();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            if (placingProcedureDamage == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        if (hit.transform.tag == "Grid")
                        {
                            hitted = hit.transform.gameObject;
                            Instantiate(DamageTower, hitted.transform.position, Quaternion.identity);
                            SoundManagerScript.PlaySound("Ping_Minimal UI Sounds");
                            //Destroy(hitted);
                            placingProcedureDamage = false;

                            placingText.SetActive(false);
                            DamageButton.SetActive(true);
                            SlowButton.SetActive(true);
                        }
                    }
                }
            }
            else if (placingProcedureSlow == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        if (hit.transform.tag == "Grid")
                        {
                            hitted = hit.transform.gameObject;
                            Instantiate(SlowTower, hitted.transform.position, Quaternion.identity);
                            SoundManagerScript.PlaySound("Ping_Minimal UI Sounds");
                            //Destroy(hitted);
                            placingProcedureSlow = false;

                            placingText.SetActive(false);
                            DamageButton.SetActive(true);
                            SlowButton.SetActive(true);
                        }
                    }
                }
            }
        }

        moneyText.text = "$" + money;

        if (money <= 0)
        {
            SoundManagerScript.PlaySound("GameOver");
            SceneManager.LoadScene("GameOver");
        }
        
    }

    public void CreatePath()
    {
        panels = GameObject.FindGameObjectsWithTag("Grid");

        Instantiate(path, panels[3].transform.position, Quaternion.identity);
        Destroy(panels[3]);

        Instantiate(path, panels[13].transform.position, Quaternion.identity);
        Destroy(panels[13]);

        Instantiate(path, panels[23].transform.position, Quaternion.identity);
        Destroy(panels[23]);

        Instantiate(path, panels[24].transform.position, Quaternion.identity);
        Destroy(panels[24]);

        Instantiate(path, panels[25].transform.position, Quaternion.identity);
        Destroy(panels[25]);

        Instantiate(path, panels[26].transform.position, Quaternion.identity);
        Destroy(panels[26]);

        Instantiate(path, panels[36].transform.position, Quaternion.identity);
        Destroy(panels[36]);

        Instantiate(path, panels[46].transform.position, Quaternion.identity);
        Destroy(panels[46]);

        Instantiate(path, panels[56].transform.position, Quaternion.identity);
        Destroy(panels[56]);

        Instantiate(path, panels[66].transform.position, Quaternion.identity);
        Destroy(panels[66]);

        Instantiate(path, panels[76].transform.position, Quaternion.identity);
        Destroy(panels[76]);

        Instantiate(path, panels[75].transform.position, Quaternion.identity);
        Destroy(panels[75]);

        Instantiate(path, panels[74].transform.position, Quaternion.identity);
        Destroy(panels[74]);

        Instantiate(path, panels[84].transform.position, Quaternion.identity);
        Destroy(panels[84]);

        Instantiate(path, panels[94].transform.position, Quaternion.identity);
        Destroy(panels[94]);


        for (int i = 0; i < 100; i++)
        {
            panels[i] = null;
        }

        paths = GameObject.FindGameObjectsWithTag("Path");
    }

    public void BuyDamageTower()
    {
        if (money >= 50)
        {
            money -= 50;
            placingText.SetActive(true);
            placingProcedureDamage = true;
            DamageButton.SetActive(false);
            SlowButton.SetActive(false);
        }      
    }

    public void BuySlowTower()
    {
        if (money >= 50)
        {
            money -= 50;
            placingText.SetActive(true);
            placingProcedureSlow = true;
            DamageButton.SetActive(false);
            SlowButton.SetActive(false);
        }
    }
}
