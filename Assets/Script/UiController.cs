using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiController : MonoBehaviour
{
    public GameObject startUi;
    public GameObject settingUi;
    public GameObject infoUi;
    public GameObject rankUi;
    public GameObject versionUi;
    public GameObject infoBtn;
    public GameObject gameInfoUi;
    public GameObject gameOverPanel;

    public TMP_Text bestScoreText;
    public TMP_Text currentScoreText;
    public TMP_Text endMyScore;
    public TMP_Text endBestScore;

    public static UiController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeUI();
    }

    public void InitializeUI()
    {
        startUi.SetActive(true);
        settingUi.SetActive(false);
        infoUi.SetActive(false);
        rankUi.SetActive(false);
        versionUi.SetActive(true);
        infoBtn.SetActive(true);
        gameInfoUi.SetActive(false);
        UpdateScoreUI();
    }

    public void OnSettingBtn()
    {
        PlayButtonClickSound();
        Time.timeScale = 0.0f;
        settingUi.SetActive(true);
    }

    public void ExitSettingBtn()
    {
        Time.timeScale = 1.0f;
        settingUi.SetActive(false);
        PlayButtonClickSound();
    }

    public void OnStartBtn()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("MainScene");
        startUi.SetActive(false);
        versionUi.SetActive(false);
        infoBtn.SetActive(false);
        gameInfoUi.SetActive(true);

        ScoreManager.instance.ResetTotalScore();
    }

    public void OnRankingBtn()
    {
        rankUi.SetActive(true);
        PlayButtonClickSound();
    }

    public void OnGameEndBtn()
    {
        PlayButtonClickSound();
        Application.Quit();
    }

    public void OnInfoBtn()
    {
        infoUi.SetActive(true);
        PlayButtonClickSound();
    }

    public void OffInfoBtn()
    {
        infoUi.SetActive(false);
        PlayButtonClickSound();
    }

    public void OffRankBtn()
    {
        rankUi.SetActive(false);
        PlayButtonClickSound();
    }

    private void PlayButtonClickSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClickSound();
        }
    }

    public void OnGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        UpdateScoreUI();
    }

    public void OnRetryBtn()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
        gameOverPanel.SetActive(false);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClickSound();
        }

        InitializeUI();
    }

    private void UpdateScoreUI()
    {
        if (ScoreManager.instance != null)
        {
            bestScoreText.text = $"Best Score : {ScoreManager.instance.GetBestScore()}";
            currentScoreText.text = $"Recent Score : {ScoreManager.instance.GetTotalScore()}";
            endMyScore.text = $"My Score : {ScoreManager.instance.GetTotalScore()}";
            endBestScore.text = $"Best Score : {ScoreManager.instance.GetBestScore()}";
        }
    }
}
