using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Hotkey : MonoBehaviour
{
    public PlayableDirector director;
    public Transform TLight;
    public GameObject clickme;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene.instance.LoadA("Opening 3");
            print("space key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            director.Play();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            TLight.position = TLight.transform.position+Vector3.up;
        }

        if( Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false; //unity editor用的停止play mode方法
            #else
            Application.Quit(); //build成專案檔用的停止play mode方法
            #endif
        }
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            clickme.SetActive(true);
        }


    }
}
