using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) //Tag Object �� ���� �� Hit ����� �߻�
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            Debug.Log("Hit");
        }
    }
}
