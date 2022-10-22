using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isgameStarted;
    public static bool mute = false;
    public static bool isPaused = false;

    public static int currentLevelIndex;
    public static int numberOfRingspassed;
    public static int score = 0;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;

    public Slider gameProgressSlider;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;
    public GameObject gamePausedPanel;

    private SpawnManager spawnManager;


    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        spawnManager = GameObject.FindGameObjectWithTag("Spawn Manager").GetComponent<SpawnManager>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        numberOfRingspassed = 0;
        highScore.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        gameOver = levelCompleted = isgameStarted = false;

        AdManager.instance.RequestInterstitial();
        spawnManager.InstantiateMoreBalls();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isgameStarted/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isgameStarted*/)
        {
            if ( EventSystem.current.IsPointerOverGameObject()/*EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)*/)
                return;

            if (PlayerPrefs.GetInt("CurrentLevelIndex") <= 5)
            {
                GameObject.FindGameObjectWithTag("PlayerClone").SetActive(false);
            }

            isgameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }

        //update the UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfRingspassed * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();

        if (isPaused && Input.GetMouseButtonDown(0)) //Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            Time.timeScale = 1;
            Debug.Log("resume");
            isPaused = false;
            gamePausedPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
        }

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            if (Random.Range( 0, 3) == 0)
            {
                AdManager.instance.ShowInterstitial();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (PlayerPrefs.GetInt("CurrentLevelIndex") <= 5)
                {
                    score = 0;
                    SceneManager.LoadScene("Level");
                }

                else
                {
                    score = 0;
                    SceneManager.LoadScene("Level");
                    spawnManager.InstantiateMoreBalls();
                }

            }
        }

        if (levelCompleted)
        {

            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
            levelCompletedPanel.SetActive(true);


            if (Input.GetButtonDown("Fire1"))
            {
                 if (PlayerPrefs.GetInt("CurrentLevelIndex") <= 5)
                 {
                     SceneManager.LoadScene("Level");
                 }

                 else
                 {
                     SceneManager.LoadScene("Level");
                     spawnManager.InstantiateMoreBalls();
                 }
            }
        }
    }

}
