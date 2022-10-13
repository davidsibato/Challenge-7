using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted;
    public static bool mute = false;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;
    public GameObject DragToRotate;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public static int numberOfPassedRings;
    public static int score = 0;
    public static int level = 1;

    // Start is called before the first frame update
    
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
    
    void Start()
    {
         Time.timeScale = 1;
         numberOfPassedRings = 0;
         highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
       isGameStarted = gameOver = levelCompleted = false;

    }

    // Update is called once per frame
    void Update()
    {
        //update our ui
        //changed here to increase level   currentLevelIndex
        currentLevelText.text = level.ToString();
          nextLevelText.text = (level+1).ToString();

         int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
          gameProgressSlider.value = progress;
            
          scoreText.text = "Score\n" + score.ToString();
        if (Input.GetMouseButton(0))
        {
            DragToRotate.SetActive(false);
        }
        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
              {
                return;
              }
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
            
        }
       
       
       
       
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if(Input.GetButtonDown("Fire1"))
            {
                if(score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                score = 0;
                level = 1;
                SceneManager.LoadScene("level");
            }
        }
   

   
        if(levelCompleted)
        {
            Time.timeScale = 0;
            levelCompletedPanel.SetActive(true);

            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("level");
                level++;
                Debug.Log(currentLevelIndex);
            }
        }
   
    }
}
