using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class MapMove : MonoBehaviour
{
    public Transform cameraTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameManager.instance.cameraTransform;
        for(int i = 0; i < 3; i++) 
        MapManager.instance.SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = MapManager.instance.speed;
        transform.Translate(Vector3.forward * Time.deltaTime * speed *-1);
        if (cameraTransform.transform.position.z-5f > transform.position.z)
        {
            StartCoroutine("DestroyMap");
        }

    }

    IEnumerator DestroyMap()
    {
        yield return null;
        MapManager.instance.SpawnArea(transform.position.z);
        Destroy(gameObject);
    }
}
