
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int MaxScore = 7;
    
    Goal left;
    Goal right;
    GameObject LeftGoal;
    GameObject RightGoal;
    int prevLeft = 0;
    int prevRight = 0;
    bool leftStart = true;

    public bool LeftStart { get => leftStart; }
    public int LeftScore { get => left.Score; }
    public int RightScore { get => right.Score; }

    public GameObject winUI;
    public Text scoreText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        LeftGoal = GameObject.Find("LeftGoal");
        RightGoal = GameObject.Find("RightGoal");
        left = LeftGoal.GetComponent<Goal>();
        right = RightGoal.GetComponent<Goal>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = right.Score + " - " + left.Score;

        updateLeftStart();

        if(right.Score == MaxScore)
        {
            LeftGoal.SetActive(false);
            RightGoal.SetActive(false);
            winUI.SetActive(true);
            winText.text = "Left\nWins\n" + right.Score + " - " + left.Score;
        }
        if(left.Score == MaxScore)
        {
            LeftGoal.SetActive(false);
            RightGoal.SetActive(false);
            winUI.SetActive(true);
            winText.text = "Right\nWins\n" + right.Score + " - " + left.Score;
        }

        prevLeft = left.Score;
        prevRight = right.Score;
    }

    public void updateLeftStart()
    {
        if (left.Score > prevLeft)
        {
            leftStart = true;
        }
        if (right.Score > prevRight)
        {
            leftStart = false;
        }
    }
}
