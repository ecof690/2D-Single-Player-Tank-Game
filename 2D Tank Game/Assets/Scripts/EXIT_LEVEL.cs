using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EXIT_LEVEL : MonoBehaviour
{
    public GameObject exit_fr_lev;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        exit_fr_lev.SetActive(true);

        Invoke("exit_scene", 4.0f);
    }

    void exit_scene()
    {
        SceneManager.LoadScene(0);
    }
}
