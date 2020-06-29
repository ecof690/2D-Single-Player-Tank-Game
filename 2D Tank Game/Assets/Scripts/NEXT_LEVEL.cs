using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NEXT_LEVEL : MonoBehaviour
{
    public GameObject compl_lev_UI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        compl_lev_UI.SetActive(true);

        Invoke("next_scene", 4.0f);
    }

    void next_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
