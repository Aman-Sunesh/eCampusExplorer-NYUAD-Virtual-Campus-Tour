using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneSwitcher : MonoBehaviour
{
     // This public function can be called to switch to the Main Menu scene
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
