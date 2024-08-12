using UnityEngine;
public class Losing : MonoBehaviour
{
    public GameObject loserStickMan;

    public GameObject defStickMan;

    public GameObject failText;

    public GameObject failButton;

    public Rigidbody[] allRigidBodies;

    public Material failColor;

    public AudioClip losingSound;

    public Camera activeCamera;

    public static bool gameEnding;


    void Start()
    {
        gameEnding = false;

        for (int i=0; i < allRigidBodies.Length;i++)
        {
            allRigidBodies[i].isKinematic = true;
            allRigidBodies[i].useGravity = false;
            
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Wall") && gameEnding == false)
        {
            gameEnding = true;

            GameStarting.isGameStarted = false;

            LosingAnimation();

            EndGame();

            RenderSettings.skybox = failColor;

            gameObject.PlayAudio(losingSound);
        }
    }

    void Update()
    {
        failText.SetActive(gameEnding);
        failButton.SetActive(gameEnding);
    }

    private void EndGame()
    {
        activeCamera.GetComponent<CameraMovement>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<RoadSpawning>().enabled = false;
    }

    private void LosingAnimation()
    {
        loserStickMan.transform.position = defStickMan.transform.position;

        defStickMan.SetActive(false);

        loserStickMan.GetComponent<Animator>().enabled = false;

        for (int i = 0; i < allRigidBodies.Length; i++)
        {
            allRigidBodies[i].isKinematic = false;
            allRigidBodies[i].useGravity = true;
        }
    }

}
