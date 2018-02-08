using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	public static int score = 0;
    public Text text;

    void Awake ()
    {
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
    }
}
