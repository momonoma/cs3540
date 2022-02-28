using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public static bool isGameOver = false;
   

    private void Awake()
    {
        isGameOver = false;
       
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


    }



    public void LevelLost()
    {
        Invoke("LoadCurrentLevel", 2);

    }



    void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
