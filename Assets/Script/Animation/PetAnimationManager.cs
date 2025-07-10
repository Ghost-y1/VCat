using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimationManager : MonoBehaviour
{
    public static PetAnimationManager Instance { get; private set; }

    private Animator animator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            animator = GetComponent<Animator>();
        }

        else
        {
            Destroy(gameObject); 
        }
    }
}
