using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2collision : MonoBehaviour
{
    public GameManager GM;
    public AudioSource yay;
    public GameObject rsbutton;
    public Canvas canvas;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Right Barrier")
        {
            Debug.Log("p1 win");
            GM.win = true;
            GM.Ctext.text = "Player 1 wins!";
            yay.Play();
            GameObject rspawn = Instantiate(rsbutton, new Vector3(460, 153, 0), Quaternion.identity);
            rspawn.transform.SetParent(canvas.transform);
        }
    }
}
