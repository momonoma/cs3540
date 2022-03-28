using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static bool isGameOver = false;
    public static bool enemiesDead = false;
    public static bool bossDead = false;
    public static bool playerDead = false;
    public AudioClip win;
    public AudioClip lose;
    public Text statusText;

    private void Awake()
    {
        isGameOver = false;
        enemiesDead = false;
        playerDead = false;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemies == 0)
            {
                enemiesDead = true;
            }

            if (bossDead)
            {
                LevelWon();
            }

            if (playerDead)
            {
                LevelLost();
            }

        }
    }



    public void LevelLost()
    {
        setGameOverStatus("Rebooting...", lose);
        Invoke("LoadCurrentLevel", 5);

    }

    public void LevelWon()
    {
        setGameOverStatus("Level Clear!", win);
    }

    void setGameOverStatus(string gameTextMessage, AudioClip sfx)
    {
        isGameOver = true;
        AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position);
        statusText.text = gameTextMessage;
        statusText.enabled = true;
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
