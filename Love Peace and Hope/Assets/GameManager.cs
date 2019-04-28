using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using UnityEngine;
using EZCameraShake;
using TMPro;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public GameObject blocks;
    public GameObject canvas;
    public GameObject p1;
    public GameObject p2;
    public float Speed1;
    public Rigidbody2D rgbd1;
    public float Speed2;
    public Rigidbody2D rgbd2;
    public float timer;
    public GameObject blocksprefab;
    public GameObject beachprefab;
    public GameObject waterprefab;
    public int p1score;
    public int p2score;
    public TextMeshProUGUI p1s;
    public TextMeshProUGUI p2s;
    public TextMeshProUGUI Ctext;
    public int scorelength;
    public GameObject p1flash;
    public GameObject p2flash;
    public Image white;
    public Animator flash;
    public AudioSource whoop;
    public float force;
    public AudioClip first;
    public AudioClip second;
    public AudioClip third;
    public AudioClip fourth;
    public AudioClip fifth;
    public AudioClip sixth;
    public AudioClip seventh;
    public GameObject music;
    public bool win;
    public bool r1;
    public bool r2;
    public bool r3;
    public bool r1s;
    public bool r2s;
    public bool r3s;
    public bool gameover;
    public float round1timer;
    public float wintimer;
    public int p1rscore;
    public int p2rscore;
    public int roundno;
    public GameObject star11;
    public GameObject star12;
    public GameObject star21;
    public GameObject star22;
    public GameObject rsbutton;
    public GameObject chselectbutton;
    public AudioSource cdbeep;



    // Start is called before the first frame update
    void Start()
    {
        roundno = 1;
        r1s = false;
        r2s = false;
        r3s = false;
        gameover = false;
        scorelength = 4;
        
        for (int i = 0; i <= 3; i++)
			
        {
            Instantiate(beachprefab, new Vector3(  -9 + i * 8, -4f , -2), Quaternion.identity);
            //spawn.transform.SetParent(canvas.transform);
        }
        
        for (int i = 0; i <= 10; i++)
			
        {
            Instantiate(waterprefab, new Vector3(  -9 + i * 1.8f, -4.65f , -3f), Quaternion.identity);
            //spawn.transform.SetParent(canvas.transform);
        }

        AudioClip bop = whoop.clip;

        win = false;
        
        Destroy(GameObject.Find("Music manager"));
        //Destroy(GameObject.Find("Music Manager"));


//        var trans = 0.5f;
//        var color = p1flash.GetComponent<Renderer>().material.color;
//        color.a = trans;

//        white = GetComponent<Image>();
//        Color tempColor = white.color;
//        tempColor.a = 1;
//        white.color = tempColor;
    }

    // Update is called once per frame

    public void playboop(AudioClip music)
    {
        //whoop.Stop();
        whoop.clip = music;
        //whoop.Play();
    }
    
    void Update()
    {
       if (p1rscore == 1)
       {
           star11.SetActive(true);
       }
       
       if (p1rscore == 2)
       {
           star12.SetActive(true);
       }

       if (p2rscore == 1)
       {
           star21.SetActive(true);
       }

       if (p2rscore == 2)
       {
           star22.SetActive(true);
       }
        
       if (roundno == 1)
       {
           r1 = true;
       }
       
       else if (roundno == 2)
       {
           r1 = false;
           r1s = false;
           r2 = true;
       }

       if (p1rscore >= 2 || p2rscore >= 2)
       {
           win = true;
           gameover = true;
           gover();
       }
       
       if (roundno == 3 && gameover == false)
       {
           r1 = false;
           r1s = false;
           r2 = false;
           r2s = false;
           r3 = true;
       }
        
       if (r1 == true && r1s == false)
       {
            round1();
       }
       
       if (r2 == true && r2s == false)
       {
           round2();    
       }
       
       if (r3 == true && r3s == false)
       {
           round3();    
       }
        
       var sound = whoop.GetComponent<AudioClip>();
       
       //timer -= Time.deltaTime;
       //CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);

        
       //p1.transform.position += new Vector3(Speed, 0);
       //rgbd1.AddForce(new Vector2(Speed1,0), ForceMode2D.Force);
       
       string scorep1 = p1score.ToString();
       int numZeros = scorelength - scorep1.Length;
       //Debug.Log(numZeros);

       string newScore = "";
       
       for(int i = 0; i < numZeros; i++)
       {
           newScore += "0";
       }

       //newScore += scorep1;
       p1s.text = newScore + scorep1;
       
       string scorep2 = p2score.ToString();
       int numZeros2 = scorelength - scorep2.Length;
       //Debug.Log(numZeros2);

       string newScore2 = "";
       
       for(int i = 0; i < numZeros2; i++)
       {
           newScore2 += "0";
       }

       //newScore += scorep1;
       p2s.text = newScore2 + scorep2;
       
       if (timer <= 0)
       {
           rgbd1.AddForce(new Vector2(Speed1, 0), ForceMode2D.Force);
           rgbd2.AddForce(new Vector2(-Speed2, 0), ForceMode2D.Force);
       }

       if ((win == false && r1s == true) || (win == false && r2s == true) || (win == false && r3s == true)) 
       {
           timer -= Time.deltaTime;

           if (Input.GetKeyDown(KeyCode.A))
           {
               Speed1 += 1;
               p1score += 1;
               Debug.Log(Speed1);
               CameraShaker.Instance.ShakeOnce(force, 4f, 0.1f, 1f);
               //p1flash.GetComponent<Renderer> ().material.color.a = 0;
               p1flash.GetComponent<Animator>().Play("flahs");
               whoop.Play();
               //whoop.clip = first;
               //playboop(first);
           }

           else
           {
               p1flash.GetComponent<Animator>().Play("Idle");
           }

//           if (timer <= 0)
//           {
//               rgbd1.AddForce(new Vector2(Speed1, 0), ForceMode2D.Force);
//               rgbd2.AddForce(new Vector2(-Speed2, 0), ForceMode2D.Force);
//           }

           //rgbd2.AddForce(new Vector2(-Speed2,0), ForceMode2D.Force);

           if (Input.GetKeyDown(KeyCode.L))
           {
               Speed2 += 1;
               p2score += 1;
               Debug.Log(Speed2);
               CameraShaker.Instance.ShakeOnce(force, 4f, 0.1f, 1f);
               p2flash.GetComponent<Animator>().Play("flahs");
               whoop.Play();
               //whoop.clip = first;
               playboop(first);
           }

           else
           {
               p2flash.GetComponent<Animator>().Play("Idle");
           }

           if (p1score >= 10 || p2score >= 10)
           {
               force = 1;
               //playboop(second);
               //whoop.clip = second;
               //whoop.Play();
           }

           if (p1score >= 30 || p2score >= 30)
           {
               force = 2;
               //playboop(third);
               //whoop.clip = third;
           }

           if (p1score >= 50 || p2score >= 50)
           {
               force = 4;
               //Changeboop(fourth);
           }

           if (p1score >= 100 || p2score >= 100)
           {
               force = 6;
               //Changeboop(fifth);
           }

           if (p1score >= 150 || p2score >= 150)
           {
               force = 8;
               //Changeboop(sixth);
           }

           if (p1score >= 200 || p2score >= 200)
           {
               force = 10;
               //Changeboop(seventh);
           }
       }

       if (win == true && gameover == false)
       {
           reset();
       }

//       if (p1score >= 130 || p2score >= 1300)
//       {
//           force = 12;
//       }
//       
//       if (p1score >= 150 || p2score >= 150)
//       {
//           force = 14;
//       }
    }


    public void round1()
    {
        round1timer += Time.deltaTime;
        if (round1timer >= 2)
        {
            Ctext.text = "Ready!";
        }
        
        if (round1timer >= 3)
        {
            Ctext.text = "Get Set!";
        }
        
        if (round1timer >= 4)
        {
            Ctext.text = "Hug!!!";
            round1timer = 0;
            r1s = true;
        }
        
    }

    public void round2()
    {
        round1timer += Time.deltaTime;

        Ctext.text = "Round 2!";

        if (round1timer >= 2)
        {
            Ctext.text = "Ready!";
        }

        if (round1timer >= 3)
        {
            Ctext.text = "Get Set!";
        }

        if (round1timer >= 4)
        {
            Ctext.text = "Hug!!!";
            round1timer = 0;
            r2s = true;
        }
    }
    
    public void round3()
    {
        round1timer += Time.deltaTime;

        Ctext.text = "Final Round!";

        if (round1timer >= 2)
        {
            Ctext.text = "Ready!";
        }

        if (round1timer >= 3)
        {
            Ctext.text = "Get Set!";
        }

        if (round1timer >= 4)
        {
            Ctext.text = "Hug!!!";
            round1timer = 0;
            r3s = true;
        }
    }


    public void reset()
    {
        wintimer += Time.deltaTime;
        
        if (wintimer >= 2)
        {
            Ctext.text = "";
            p1score = 0;
            p2score = 0;
            Speed1 = 0;
            Speed2 = 0;
            force = 0.5f;
            timer = 5;
            wintimer = 0;
            p1.transform.position = new Vector3(-6.0f, -2.59f, -1.0f);
            p2.transform.position = new Vector3(6.0f, -2.59f, -1.0f);
            p1.transform.rotation = Quaternion.Euler(0, 0, 0);;
            p2.transform.rotation = Quaternion.Euler(0, 0, 0);;
            roundno += 1;
            win = false;
        }
    }
    
    public void gover()
    {
        rsbutton.SetActive(true);
        chselectbutton.SetActive(true);
    }
    
    public void restart()
    {
        SceneManager.LoadScene(sceneName:"Gameplay");

    }
    
    public void characterselect()
    {
        SceneManager.LoadScene(sceneName:"Character Select");
        DontDestroyOnLoad(music);
    }

}
