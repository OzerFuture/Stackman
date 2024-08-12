using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroStackController : MonoBehaviour
{
    public CameraMovement cameraShake;
    public AudioClip Clip;
    public List<GameObject> blockList = new ();
    private GameObject _lastBlockObject;

    private void Start()
    {
        UpdateLastBlockObject();
    }

    public void IncreaseNewBlock(GameObject _gameObject)
    {
        transform.position += 1.03f * Vector3.up;
        _gameObject.transform.position = _lastBlockObject.transform.position - 1.03f * Vector3.up;
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);

        UpdateLastBlockObject();

        gameObject.PlayAudio(Clip);

    }


    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        blockList.Remove(_gameObject);

        UpdateLastBlockObject();

        Handheld.Vibrate();

        StartCoroutine(cameraShake.Shake(.2f, 0.98f));

    }
    public void UpdateLastBlockObject()
    {
        _lastBlockObject = blockList[^1];
        
    }

}
