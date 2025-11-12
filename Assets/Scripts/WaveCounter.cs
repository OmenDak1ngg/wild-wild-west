using System;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    private int _count;

    public event Action<int> CountUpdated;

    private void Awake()
    {
        _count = 0;
        CountUpdated?.Invoke(_count);
    }  

    public void IncreaseCount()
    {
        _count++;
        CountUpdated?.Invoke(_count); 
    }
}
