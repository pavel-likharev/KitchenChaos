using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Player player;

    private const string IS_WALKING = "IsWalking";

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(IS_WALKING, player.IsWalking());
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
