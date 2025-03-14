using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] InputField inputField;
    
    
    public void SaveName()
    {
        string input = inputField.text;
        MainManagerx.Instance.SaveCurrentName(input);
        Debug.Log("se ha guardado el nombre" + input);
    }
    public void startNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
 
#endif
    }
}
