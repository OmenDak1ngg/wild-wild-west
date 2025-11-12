
using TMPro;
using UnityEngine;


public class WaveCounterViewer : MonoBehaviour
{
    [SerializeField] private WaveCounter _counter;
    [SerializeField] private TextMeshProUGUI _tmp;

    private void OnEnable()
    {
        _counter.CountUpdated += UpdateCount;
    }

    private void OnDisable()
    {
        _counter.CountUpdated -= UpdateCount;
    }

    private void UpdateCount(int count)
    {
        _tmp.text = count.ToString();
    }
}
