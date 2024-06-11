using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text m_ScoreTextMeshPro;
    public TMP_Text m_BestScoreTextMeshPro;

    float totalScore;
    float bestScore;

    Data data;

    void Start()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);

        totalScore = 0.0f;

        data = DataManager.Instance.Load();
        Debug.Log(data.bestScore);
        bestScore = data.bestScore;
        m_BestScoreTextMeshPro.text = bestScore.ToString();
    }
    public void UpdateScore(float score)
    {
        totalScore += score;
        m_ScoreTextMeshPro.text = totalScore.ToString();

        if (totalScore > bestScore)
        {
            bestScore = totalScore;
            m_BestScoreTextMeshPro.text = bestScore.ToString();

            DataManager.Instance.Save(new Data(bestScore));
        }
    }

    public float GetTotalScore()
    {
        return totalScore;
    }

    public float GetBestScore()
    {
        return bestScore;
    }

    public void ResetTotalScore()
    {
        totalScore = 0;
        m_ScoreTextMeshPro.text = totalScore.ToString();
    }
}
