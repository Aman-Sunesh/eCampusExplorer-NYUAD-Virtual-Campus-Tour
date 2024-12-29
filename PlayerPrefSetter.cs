using UnityEngine;

public class PlayerPrefSetter : MonoBehaviour
{
    // This is the value that you can set in the Unity Editor.
    public string globalStateValue = "A";

    private void Awake()
    {
        SetGlobalState(globalStateValue);
    }

    public void SetGlobalState(string value)
    {
        PlayerPrefs.SetString("globalState", value);
    }
}
