using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{

    public float timer;
    public GameObject bg;
    public Button start;
    public GameObject musicplayer;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("start");
            SceneManager.LoadScene(sceneName:"Main Menu");
        }
        
        timer -= Time.deltaTime;
        //Debug.Log(timer);
        if (timer <= 0)
        {
            Destroy(bg);
        }
    }

    public void ChangeScene()
    {
        Debug.Log("play");
        SceneManager.LoadScene(sceneName:"Character Select");
        DontDestroyOnLoad(musicplayer);

    }
    
    public void ChangeSceneinstructions()
    {
        Debug.Log("instructions");
        SceneManager.LoadScene(sceneName:"Instructions");
        DontDestroyOnLoad(musicplayer);
    }
}
