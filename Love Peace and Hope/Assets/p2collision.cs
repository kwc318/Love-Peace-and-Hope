using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2collision : MonoBehaviour
{
    public GameManager GM;
    public AudioSource yay;
    public GameObject rsbutton;
    public GameObject chselectbutton;
    public Transform buttonpos;
    public Canvas canvas;
    public Sprite yellow;
    public Sprite orange;
    public Sprite brown;
    public Sprite white;
    public Sprite black;
    public p1collision p1;
        
    // Start is called before the first frame update
    void Start()
    {
        if (cselect.PlayerSelection2 == 1)
        {
            GetComponent<SpriteRenderer>().sprite = yellow;
        }
        
        if (cselect.PlayerSelection2 == 2)
        {
            GetComponent<SpriteRenderer>().sprite = orange;
        }
        
        if (cselect.PlayerSelection2 == 3)
        {
            GetComponent<SpriteRenderer>().sprite = brown;
        }
        
        if (cselect.PlayerSelection2 == 4)
        {
            GetComponent<SpriteRenderer>().sprite = white;
        }
        
        if (cselect.PlayerSelection2 == 5)
        {
            GetComponent<SpriteRenderer>().sprite = black;
        }
        
        Debug.Log(cselect.PlayerSelection2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GM.win == false)
        {
            if (collision.gameObject.name == "Right Barrier")
            {
                Debug.Log("p1 win");
                GM.win = true;
                GM.Ctext.text = p1.GetComponent<SpriteRenderer>().sprite.name.ToString() + " Has More Hug Power!";
                yay.Play();
//                GameObject rspawn = Instantiate(rsbutton, buttonpos.position, Quaternion.identity);
//                rspawn.transform.SetParent(canvas.transform);
                //rsbutton.SetActive(true);
                //chselectbutton.SetActive(true);
                GM.Speed1 = 1;
                GM.Speed2 = 0;
                GetComponent<SpriteRenderer>().sprite.name.ToString();
                GM.p1rscore += 1;

            }
        }
//        if (collision.gameObject.name == "Right Barrier")
//        {
//            Debug.Log("p1 win");
//            GM.win = true;
//            GM.Ctext.text = "Player 1 wins!";
//            yay.Play();
//            GameObject rspawn = Instantiate(rsbutton, new Vector3(780, 200, 0), Quaternion.identity);
//            rspawn.transform.SetParent(canvas.transform);
//            GM.Speed1 = 1;
//            GM.Speed2 = 0;
//        }
    }
}
