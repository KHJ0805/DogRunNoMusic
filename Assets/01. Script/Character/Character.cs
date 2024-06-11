using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController controller;
    
    private void Awake()
    {
        CharacterManager.Instance.Character = this;
        controller = GetComponent<CharacterController>();
    }
}
