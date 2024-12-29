using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ButtonFunctions : MonoBehaviour
{
    public GameObject AboutText;

    public void StartTour()
    {
        // Load the scene with the name "1_WC_to_Palms"
        SceneManager.LoadScene("1_WC_to_Palms");
    }

    public void About()
    {
        // Toggle the visibility of the AboutText GameObject
        if (AboutText != null)
        {
            AboutText.SetActive(!AboutText.activeSelf);
        }
    }

 public void Exit()
    {
        // Logs the quit request in the Unity Editor console
        Debug.Log("Quit requested");

#if UNITY_EDITOR
        // Stop playing the scene in the Unity Editor
        EditorApplication.isPlaying = false;
#else
        // Quit the application
        Application.Quit();
#endif
    }
}
