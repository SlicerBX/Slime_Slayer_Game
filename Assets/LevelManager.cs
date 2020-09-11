//UnityEngine is given by defualt but UnityEngine.UI must be typed up
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text scoreNum;
    public int score;

    public void updateScore()
    {
        score++;
        //CanvasManager.Instance.SetScore(score);
        scoreNum.text = string.Format("KILLS    {0}", score);
    }
}
