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

    private void Awake()
    {
        isGameOver = false;
        enemiesDead = false;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies == 0)
        {
            enemiesDead = true;
        }

    }



    public void LevelLost()
    {
        Invoke("LoadCurrentLevel", 2);

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
