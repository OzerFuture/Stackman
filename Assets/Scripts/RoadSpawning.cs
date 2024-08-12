using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawning : MonoBehaviour
{
    public GameObject roadPrefab;

    [SerializeField] private float _interval = 10f;
    private float _spawnDistance = 90f;
    private GameObject _newRoad;
    private Animator _animator;


    void Start()

    {
            StartCoroutine(TriggerEvent());
    }


    IEnumerator TriggerEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);

            SpawnRoad();

            AnimateRoad();
        }
    }

    private void SpawnRoad()
    {
            _spawnDistance += 30;
            Vector3 spawnPosition = new (0, 0, _spawnDistance);
            _newRoad = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);
    }

    private void AnimateRoad()
    {
        
       _animator = _newRoad.GetComponent<Animator>();
       _animator.SetTrigger("Move");

    }
  
}
