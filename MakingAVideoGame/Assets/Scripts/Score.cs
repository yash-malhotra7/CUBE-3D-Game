using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text highScore;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        highScore.text = player.position.z.ToString("0");
    }
}
