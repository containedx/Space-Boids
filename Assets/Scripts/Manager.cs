using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public FlockManager flock;
    public GameObject caption;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(caption, 2.5f);
    }

    void LateUpdate()
    {
        if(flock.boids.Count == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("End");
            }


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
