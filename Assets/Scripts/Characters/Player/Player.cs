using System.Collections;
using UnityEngine;


public class Player : Character
{
    private void OnEnable()
    {
        Health.Dead += OnDead;
    }

    private void OnDisable()
    {
        Health.Dead -= OnDead;
    }

    private void OnDead()
    {
        Time.timeScale = 0f;
        Debug.Log("GameEnd");
    }
}