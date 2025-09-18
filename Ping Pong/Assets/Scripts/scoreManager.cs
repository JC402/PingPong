using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    int leftScore = 0, rightScore = 0;

    // Gives point to left player and ends game if they have 5
    public int addLeft() {
        leftScore += 1;
        leftScoreText.text = leftScore.ToString();
        if (leftScore == 5) {
            winText.text = "Left player wins!";
            return 1;
        }
        return 0;
    }

    public int addRight() {
        rightScore += 1;
        rightScoreText.text = rightScore.ToString();
        if (rightScore == 5) {
            winText.text = "Right player wins!";
            return 1;
        }
        return 0;
    }
}