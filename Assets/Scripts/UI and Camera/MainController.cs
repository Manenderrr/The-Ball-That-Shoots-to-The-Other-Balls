using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [Header("UIModes")]
    public int CurrentUIMode;
    public List<GameObject> MainMenuMode;
    public List<GameObject> SettingsMode;

    [Header("Settings")]
    public int EscapeForMenu = 1;

    [Header("Saves")]
    public string EscapeForMenuSaveName = "Escape for Menu";

    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void ChangeUIMode(int UIMode)
    {
        CurrentUIMode = UIMode;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt(EscapeForMenuSaveName, EscapeForMenu);
        PlayerPrefs.Save();
    }

    public bool LoadSettings()
    {
        EscapeForMenu = PlayerPrefs.GetInt(EscapeForMenuSaveName, 1);
        bool value = true;
        switch (EscapeForMenu)
        {
            case 0:
                value = false;
                break;
            case 1:
                value = true;
                break;
        }

        return value;
        
    }

    public void ChangeEscapeForMenuSetting()
    {
        switch (EscapeForMenu)
        {
            case 0:
                EscapeForMenu = 1;
                break;
            case 1:
                EscapeForMenu = 0;
                break;
        }
        SaveSettings();
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        LoadScene(0);
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) Cursor.visible = true;

       switch (CurrentUIMode)
        {
            case 0:
                foreach (GameObject UIElement in SettingsMode) UIElement.SetActive(false);
                foreach (GameObject UIElement in MainMenuMode) UIElement.SetActive(true);
                break;

            case 1:
                foreach (GameObject UIElement in MainMenuMode) UIElement.SetActive(false);
                foreach (GameObject UIElement in SettingsMode) UIElement.SetActive(true);
                break;
        }
    }
}
