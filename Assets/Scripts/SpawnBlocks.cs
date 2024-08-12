using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject pickup;
    public GameObject wall;
    private int _numberOfPickupsToSpawn = 3;
    private int _numberOfWallsToSpawnY;
    private float _posX;

    void Awake()
    {
        Transform childTransform = transform.GetChild(0);

        if (childTransform.localPosition.y == -0.4f)
        {

            for (int i = 4; i < _numberOfPickupsToSpawn + 4; i++)
            {
                _posX = Random.Range(-2, 1.5f);
                Vector3 randomPosition = new (_posX, transform.position.y + 1.06f, transform.position.z + 4 * i);
                Instantiate(pickup, randomPosition, Quaternion.identity);
            }


            for (int i = 0; i < 5; i++)
            {
                Vector3 posX = new (-2.3f + i, 1f, transform.position.z + 29);
                Instantiate(wall, posX, Quaternion.identity);
                _numberOfWallsToSpawnY = Random.Range(1, 5);

                for (int j = 1; j < _numberOfWallsToSpawnY; j++)
                {

                    float amountToSpawn = Random.Range(1, 10);
                    Vector3 posY = new (-2.3f + i, 1f + j, transform.position.z + 29);

                    if (amountToSpawn > 3)
                    {
                        Instantiate(wall, posY, Quaternion.identity);
                    }

                }

            }



        }
    }

}
