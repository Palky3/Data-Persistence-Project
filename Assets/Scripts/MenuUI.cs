using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] InputField nameField;

    public void StartButtonClicked()
    {
        Name.Instance.SetName(nameField.text);
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClicked()
    {
#if  UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif


    }
}
