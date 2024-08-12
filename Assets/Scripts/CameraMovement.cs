using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private float _playerPosZ;
    private float camDistance = 10.7f;
    private Vector3 StartPos => transform.position;
    public float Speed { get; set; } = 6f;

    void LateUpdate()
    {

         _playerPosZ = player.transform.position.z - camDistance;
         transform.position = new Vector3(transform.position.x, transform.position.y, _playerPosZ);
    }


    public IEnumerator Shake(float duration, float magnitude)
    {

        float elapsed = 0.0f;

        while (elapsed < duration)

        {
            float x = Random.Range(4f, 4.06f) * magnitude;
            transform.position = new Vector3(x, StartPos.y, StartPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = StartPos;
    }
}
