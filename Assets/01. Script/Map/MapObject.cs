using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    
    public Transform cameraTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        int xPos = Random.Range(-1, 2);
        int zPos = Random.Range(2, 10);
        transform.position = new Vector3(xPos, 0, zPos);
        cameraTransform = GameManager.instance.cameraTransform;
    }
   
    // Update is called once per frame
    void Update()
    {
        float speed = MapManager.instance.speed;
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -1);
        if (cameraTransform.transform.position.z > transform.position.z)
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().UpdateScore(1f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
