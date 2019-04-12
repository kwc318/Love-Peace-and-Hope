using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cselect : MonoBehaviour
{

    public static int PlayerSelection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSelect(int playernumber)
    {
        PlayerSelection = playernumber;
    }
    
}
