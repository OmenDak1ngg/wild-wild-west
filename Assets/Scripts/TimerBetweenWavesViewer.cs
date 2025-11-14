using System.Collections;
using TMPro;
using UnityEngine;

public class TimerBetweenWavesViewer : MonoBehaviour
{
    [SerializeField] private EnemyWaveStarter _waveStarter;
    [SerializeField] private TextMeshProUGUI _tmp;

    private float _startTime;

    private void OnEnable()
    {
        _waveStarter.DelayStarted += StartShowDelay;
    }

    private void OnDisable()
    {
        _waveStarter.DelayStarted -= StartShowDelay;
    }

    private void Awake()
    {
        _startTime = _waveStarter.DelayBetweenWaves;
        _tmp.text = "0";
    }

    private void StartShowDelay()
    {
        StartCoroutine(ShowDelay());
    }

    private IEnumerator ShowDelay()
    {
        float time = _startTime;

        while(time > 0)
        {
            time -= Time.deltaTime;
            _tmp.text = time.ToString("F1");

            yield return null;
        }
    }
}