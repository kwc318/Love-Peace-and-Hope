using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instcontrollet : MonoBehaviour
{
    public GameObject musicplayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeScenemenu()
    {
        Debug.Log("menu");
        SceneManager.LoadScene(sceneName:"Main Menu");
    }
    
    public void ChangeSceneplay()
    {
        Debug.Log("play");
        SceneManager.LoadScene(sceneName:"Gameplay");
        //DontDestroyOnLoad(musicplayer);
    }
}
