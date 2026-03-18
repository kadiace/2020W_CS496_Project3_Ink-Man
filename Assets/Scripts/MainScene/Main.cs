using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToExit() 
    {
        Application.Quit();
    }

    public void toTutorial()
    {
        SceneManager.LoadScene("Stage_tutorial");
    }

    public void toStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void toBoss()
    {
        SceneManager.LoadScene("Stage_boss");
    }
}
