using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    int leftScore = 0, rightScore = 0;

    public void addLeft() {
        leftScore += 1;
        leftScoreText.text = leftScore.ToString();
    }

    public void addRight() {
        rightScore += 1;
        rightScoreText.text = rightScore.ToString();
    }
}