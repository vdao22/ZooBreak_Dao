using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip dmgTower, slowTower, victory, gameOver, placeTower, takeDMG;
    static AudioSource audioSrc;
    private static SoundManagerScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dmgTower = Resources.Load<AudioClip>("cannon_01");
        slowTower = Resources.Load<AudioClip>("magic_02");
        victory = Resources.Load<AudioClip>("Victory SoundFX4");
        gameOver = Resources.Load<AudioClip>("GameOver");
        placeTower = Resources.Load<AudioClip>("Ping_Minimal UI Sounds");
        takeDMG = Resources.Load<AudioClip>("playertakedmg");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "cannon_01":
                audioSrc.PlayOneShot(dmgTower);
                break;
            case "magic_02":
                audioSrc.PlayOneShot(slowTower);
                break;
            case "Victory SoundFX4":
                audioSrc.PlayOneShot(victory);
                break;
            case "GameOver":
                audioSrc.PlayOneShot(gameOver);
                break;
            case "Ping_Minimal UI Sounds":
                audioSrc.PlayOneShot(placeTower);
                break;
            case "playertakedmg":
                audioSrc.PlayOneShot(takeDMG);
                break;
        }
    }
}
