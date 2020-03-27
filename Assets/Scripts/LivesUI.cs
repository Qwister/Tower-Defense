using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text lives_Text;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        lives_Text.text = PlayerStats.Lives.ToString();
        
    }
}
