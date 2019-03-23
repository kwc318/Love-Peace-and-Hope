using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 8; i++)
			
        {
            GameObject spawn = Instantiate(blocks, new Vector3(100.0f + i * 100, 0.0f, 1), Quaternion.identity);
            spawn.transform.SetParent(canvas.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
       //p1.transform.position += new Vector3(Speed, 0);
       rgbd1.AddForce(new Vector2(Speed1,0), ForceMode2D.Force);

       if (Input.GetKeyDown(KeyCode.A))
       {
           Speed1 += 5.0f;
           Debug.Log(Speed1);
       }
       
       rgbd2.AddForce(new Vector2(-Speed2,0), ForceMode2D.Force);

       if (Input.GetKeyDown(KeyCode.L))
       {
           Speed2 += 5.0f;
           Debug.Log(Speed2);
       }
    }
}
