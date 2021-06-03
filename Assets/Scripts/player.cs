using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float jmpSpeed;
    public Rigidbody2D rb;
    public bool isGameOver;
    public GameObject retryButton;
    public GameObject quitButton;
    public Text playScoreText;
    public Text endScoreText;
    public Text highScoreText;
    public GameObject playScore;
    public GameObject endScore;
    public GameObject highScore;
    public GameObject backName;
    public int score;

    public int highscore;



    // Start is called before the first frame update
    void Start()
    {
        isGameOver=false;
        highscore=PlayerPrefs.GetInt("high");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))  {
            if(!isGameOver)  {
                rb.velocity = Vector2.up *jmpSpeed;
            }
        }

        if(rb.transform.position.y < -3.5 || rb.transform.position.y > 4.6)  {
            isGameOver=true;
        }
        playScoreText.text = "" + score + "";
        endScoreText.text = "YOUR SCORE: " + score + "";
        if(highscore<score)  {
            PlayerPrefs.SetInt("high", score);
            highscore=score;
        }
        highScoreText.text = "HIGH SCORE: " + highscore +"";
    }

    public void OnCollisionEnter2D(Collision2D collision)  {
        if(collision.gameObject.CompareTag("Point"))  {
            if(!isGameOver)  {
                score++;
            }
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Pipe"))  {
            isGameOver = true;
        }

        if(collision.gameObject.CompareTag("End"))  {
            retryButton.SetActive(true);
            quitButton.SetActive(true);
            endScore.SetActive(true);
            highScore.SetActive(true);
            playScore.SetActive(false);
            backName.SetActive(true);
        }
    }
    
}
