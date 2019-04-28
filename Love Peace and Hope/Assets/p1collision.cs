using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1collision : MonoBehaviour
{
    public GameManager GM;
    public AudioSource yay;
    public GameObject rsbutton;
    public GameObject chselectbutton;
    public Transform buttonpos;
    public Transform chbuttonpos;
    public Canvas canvas;
    public GameObject ctext;
    public cselect c;
    public SpriteRenderer p1s;
    public Sprite yellow;
    public Sprite orange;
    public Sprite brown;
    public Sprite white;
    public Sprite black;
    public p2collision p2;
    
    // Start is called before the first frame update
    void Start()
    {
        if (cselect.PlayerSelection1 == 1)
        {
            GetComponent<SpriteRenderer>().sprite = yellow;
        }
        
        if (cselect.PlayerSelection1 == 2)
        {
            GetComponent<SpriteRenderer>().sprite = orange;
        }
        
        if (cselect.PlayerSelection1 == 3)
        {
            GetComponent<SpriteRenderer>().sprite = brown;
        }
        
        if (cselect.PlayerSelection1 == 4)
        {
            GetComponent<SpriteRenderer>().sprite = white;
        }
        
        if (cselect.PlayerSelection1 == 5)
        {
            GetComponent<SpriteRenderer>().sprite = black;
        }
        
        Debug.Log(cselect.PlayerSelection1);
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
                GM.Ctext.text = p2.GetComponent<SpriteRenderer>().sprite.name.ToString() + " Has More Hug Power!";
                yay.Play();
//                GameObject rspawn = Instantiate(rsbutton, buttonpos.position, Quaternion.identity);
//                GameObject chselect = Instantiate(chselectbutton, chbuttonpos.position, Quaternion.identity);
//                rspawn.transform.SetParent(canvas.transform);
//                chselect.transform.SetParent(canvas.transform);
                //rsbutton.SetActive(true);
                //chselectbutton.SetActive(true);
                GM.Speed1 = 0;
                GM.Speed2 = 1;
                GM.p2rscore += 1;
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
