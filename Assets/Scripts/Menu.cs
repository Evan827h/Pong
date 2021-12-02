
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Ball;
    private Ball ball;
    public GameObject Player;
    private PlayerMovement playerMovement;
    public GameObject CompPlayer;
    private CompPlayer comp;

    public void Start()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        ball = Ball.GetComponent<Ball>();
        comp = CompPlayer.GetComponent<CompPlayer>();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Easy()
    {
        playerMovement.setSpeed(8f);
        comp.setSpeed(2f);
        ball.setAcceleration(0);
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void Normal()
    {
        playerMovement.setSpeed(8f);
        comp.setSpeed(4f);
        ball.setAcceleration(1);
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void Hard()
    {
        playerMovement.setSpeed(8f);
        comp.setSpeed(8f);
        ball.setAcceleration(3);
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
}
