using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();//quit game
            Debug.Log("bap");
        }
    }
}
