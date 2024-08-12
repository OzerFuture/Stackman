using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRaycastController : MonoBehaviour
{
    public GameObject stickman;
    public GameObject textPrefab;
    public GameObject particle;

    [SerializeField] private HeroStackController heroStackController;

    private GameObject _newText;
    private bool _isStack = false;

    private void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Players") || col.gameObject.CompareTag("Pickup"))
        {
            if (!_isStack)
            {
                _isStack = !_isStack;
                heroStackController.IncreaseNewBlock(gameObject);
                CreateText();
                Animate(stickman, "Jump");
                Animate(_newText, "Collect");
                particle.GetComponent<ParticleSystem>().Play(true);
            }
        }


        if (col.gameObject.CompareTag("Wall"))
        {
            heroStackController.DecreaseBlock(gameObject);
        }

        
    }

    private void Animate(GameObject gameObject, string animationName)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger(animationName);
    }

    private void CreateText()
    {
        Vector3 position = stickman.transform.position;
        _newText = Instantiate(textPrefab, position, Quaternion.identity);
    }    
}
