using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartDelay", levelLoadDelay);
    }

    private void StartDelay()
    {
        SceneManager.LoadScene(1);
    }
}
