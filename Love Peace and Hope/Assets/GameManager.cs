using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using TMPro;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

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
    public int p1score;
    public int p2score;
    public TextMeshProUGUI p1s;
    public TextMeshProUGUI p2s;
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



    // Start is called before the first frame update
    void Start()
    {
        scorelength = 4;
        
        for (int i = 0; i <= 8; i++)
			
        {
            Instantiate(blocksprefab, new Vector3(  -8 + i * 2, -6.0f , -2), Quaternion.identity);
            //spawn.transform.SetParent(canvas.transform);
        }

        AudioClip bop = whoop.clip;

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
       var sound = whoop.GetComponent<AudioClip>();
 
       timer -= Time.deltaTime;
       //CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);

        
       //p1.transform.position += new Vector3(Speed, 0);
       //rgbd1.AddForce(new Vector2(Speed1,0), ForceMode2D.Force);
       
       string scorep1 = p1score.ToString();
       int numZeros = scorelength - scorep1.Length;
       Debug.Log(numZeros);

       string newScore = "";
       
       for(int i = 0; i < numZeros; i++)
       {
           newScore += "0";
       }

       //newScore += scorep1;
       p1s.text = newScore + scorep1;
       
       string scorep2 = p2score.ToString();
       int numZeros2 = scorelength - scorep2.Length;
       Debug.Log(numZeros2);

       string newScore2 = "";
       
       for(int i = 0; i < numZeros2; i++)
       {
           newScore2 += "0";
       }

       //newScore += scorep1;
       p2s.text = newScore2 + scorep2;



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

       if (timer <= 0)
       {
           rgbd1.AddForce(new Vector2(Speed1, 0), ForceMode2D.Force);
           rgbd2.AddForce(new Vector2(-Speed2,0), ForceMode2D.Force);
       }
       
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
}
