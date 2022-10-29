using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresInBook : MonoBehaviour
{
    public TMPro.TextMeshProUGUI fameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fameText.text = PlayerScores.instance.fame.ToString();
    }
}
