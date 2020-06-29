using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_button : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }



}
