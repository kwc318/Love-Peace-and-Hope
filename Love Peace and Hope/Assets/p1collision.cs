using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1collision : MonoBehaviour
{
    public GameManager GM;
    public AudioSource yay;
    public GameObject rsbutton;
    public Canvas canvas;
    public GameObject ctext;
    public cselect c;
    public SpriteRenderer p1s;
        
    // Start is called before the first frame update
    void Start()
    {
        //p1s.sprite = c.PlayerSelection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GM.win == false)
        {
            if (collision.gameObject.name == "Left Barrier")
            {
                Debug.Log("p2 win");
                GM.win = true;
                GM.Ctext.text = "Player 2 wins!";
                yay.Play();
                GameObject rspawn = Instantiate(rsbutton, new Vector3(780, 200, 0), Quaternion.identity);
                rspawn.transform.SetParent(canvas.transform);
                GM.Speed1 = 0;
                GM.Speed2 = 1;
            }
        }
//        if (collision.gameObject.name == "Left Barrier")
//        {
//             Debug.Log("p2 win");
//             GM.win = true;
//             GM.Ctext.text = "Player 2 wins!";
//             yay.Play();
//             GameObject rspawn = Instantiate(rsbutton, new Vector3(780, 200, 0), Quaternion.identity);
//             rspawn.transform.SetParent(canvas.transform);
//             GM.Speed1 = 0;
//             GM.Speed2 = 1;
//        }
    }
}
