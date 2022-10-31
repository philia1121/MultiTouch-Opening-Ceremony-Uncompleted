using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public static ReloadScene instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<ReloadScene>();
            return _instance;
        }
    }
    public static ReloadScene _instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadA(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
