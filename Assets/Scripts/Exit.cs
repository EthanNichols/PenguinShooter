using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void NewGameBtn(string newGamelevel)
    {
        SceneManager.LoadSceneAsync(newGamelevel);
    }
    public void EndGame()
    {
        
        Application.Quit();
   
    }
	
}
