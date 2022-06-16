using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    //variables to toggle pause panel on and off
    public static bool isPaused;
   

    public void Paused()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;  
            Debug.Log("Game is Paused");
        }
        else
        {
            Time.timeScale = 1;
        }

    }
    private void Start()
    {

    }

}
