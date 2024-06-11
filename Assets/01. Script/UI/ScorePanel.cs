using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public TMP_Text m_LifeTextMeshPro;
    public TMP_Text m_ScoreTextMeshPro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //m_LifeTextMeshPro.text = m_ScoreTextMeshPro.text;

        m_LifeTextMeshPro.text = Hp.instance.curHp.ToString();
    }
}

