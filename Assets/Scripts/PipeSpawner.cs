using UnityEngine;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 1.5f;
    [SerializeField] private GameObject _pipePrefab;

    private float _timer;

    private List<GameObject> spawnedPipes = new();

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _maxTime)
        {
            SpawnPipe();
            _timer = 0f;
        }

        for (int i = spawnedPipes.Count - 1; i >= 0; i--)
        {
            GameObject pipe = spawnedPipes[i];

            if (pipe == null) continue;

            if (pipe.transform.position.x < -2f)
            {
                Destroy(pipe);
                spawnedPipes.RemoveAt(i);
            }
        }
    }

    void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipePrefab, spawnPos, Quaternion.identity);

        //Destroy(pipe, 10f);
        spawnedPipes.Add(pipe);
    }

    public void ResetPipes()
    {
        foreach (var pipe in spawnedPipes)
        {
            if(pipe != null)
                Destroy(pipe);
        }
        spawnedPipes.Clear();
        _timer = 0f;
        SpawnPipe();
    }
}
