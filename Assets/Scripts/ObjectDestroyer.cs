using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{

    public GameObject player;
    private float _distance;
    private float _high;

    void Update()
    {
        _distance = player.transform.position.z - transform.position.z;
        _high = transform.position.y;
        if (_distance >= 100 && _high >= 0)
        {
            Destroy(gameObject);
        }
    }
}
