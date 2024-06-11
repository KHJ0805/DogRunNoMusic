using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    private Hp hp;
    private Vector3 limit = new Vector3(0, 0, -100f);

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            hp = player.GetComponent<Hp>();
        }
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MapManager.instance.speed);
        if(transform.position.z < limit.z)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Steak"))
            {
                Heal();
                gameObject.SetActive(false);
            }
            else if (gameObject.CompareTag("Pepper"))
            {
                ChangeSpeed(1.2f, 3f);
                gameObject.SetActive(false);
            }
        }
    }

    private void Heal()
    {
        if (hp != null)
        {
            if (hp.curHp < hp.maxHp)
            {
                hp.curHp += 1;
            }
        }
    }

    void ChangeSpeed(float multiplier, float duration)
    {
        MapManager.instance.originalSpeed = MapManager.instance.speed;
        MapManager.instance.speed *= multiplier;
        Invoke("ResetSpeed", duration);
    }

    void ResetSpeed()
    {
        MapManager.instance.speed = MapManager.instance.originalSpeed;
    }
}
