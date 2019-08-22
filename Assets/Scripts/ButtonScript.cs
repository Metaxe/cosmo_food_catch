using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public void StartPlaying(){
        
        SceneManager.LoadScene(1);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }

    private void levelSwitch(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    
}
