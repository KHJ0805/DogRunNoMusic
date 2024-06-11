using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public static Hp instance;
    public int maxHp = 3;
    public int curHp;
    void Start()
    {
        if (instance == null)
            instance = this;
        curHp = maxHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (curHp > 1)
        {
            curHp -= 1;
        }

        else
        {
            curHp -= 1;
            Time.timeScale = 0f;

            if (UiController.instance != null)
            {
                UiController.instance.OnGameOverPanel();
            }
        }
    }
}
