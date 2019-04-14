using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class cselect : MonoBehaviour
{

    public static int PlayerSelection1;
    public static int PlayerSelection2;
    public Button yellow;
    public Button orange;
    public Button brown;
    public Button white;
    public Button black;
    public bool p1selected;
    public TextMeshProUGUI pselecttext;
    public AudioSource selectsound;
    public GameObject fade;
    public Canvas canvas;
    public float timer;
    public bool nextscene;

    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerSelection1 = 6;
        p1selected = false;
        nextscene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSelection1 == 1)
        {
            yellow.GetComponent<Button>().interactable = false;
        }
        
        if (PlayerSelection1 == 2)
        {
            orange.GetComponent<Button>().interactable = false;
        }
        
        if (PlayerSelection1 == 3)
        {
            brown.GetComponent<Button>().interactable = false;
        }
        
        if (PlayerSelection1 == 4)
        {
            white.GetComponent<Button>().interactable = false;
        }
        
        if (PlayerSelection1 == 5)
        {
            black.GetComponent<Button>().interactable = false;
        }

        if (nextscene == true)
        {
            timer -= Time.deltaTime;
            
            if (timer <= 0)
            {
                SceneManager.LoadScene(sceneName:"Gameplay");
            }
        }
        
        //Debug.Log(timer);

    }

    public void CharacterSelect(int playernumber)
    {
        if (p1selected == false)
        {
            PlayerSelection1 = playernumber;

            p1selected = true;

            pselecttext.text = "Second player select your character!";
            
            selectsound.Play();
        }

        else
        {
            PlayerSelection2 = playernumber;
            Debug.Log(PlayerSelection2);
            selectsound.Play();
            var spawn = Instantiate(fade, new Vector3(0, 0, 0), Quaternion.identity);
            spawn.transform.SetParent(canvas.transform);
            nextscene = true;

            //SceneManager.LoadScene(sceneName:"Gameplay");
        }
        
        //GetComponent<Button>().interactable = false;

        //SceneManager.LoadScene(sceneName:"Gameplay");
    }

//    public void disablebutton()
//    {
//        GetComponent<Button>().interactable = false;
//    }


}
