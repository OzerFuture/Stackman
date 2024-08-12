using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public GameObject trail;

    private float _leftBoundary = -2.5f;

    private float _rightBoundary = 2.5f;

    private bool _isMoving = false;

    private float _targetXPosition;

    private Vector3 _direction;

    [SerializeField] private float ForwardSpeed;
    [SerializeField] private float LateralSpeed;





    void Start()
    {
        _direction.z = 0;
    }

    void Update()
    {

        HandleInput();


        MoveForward();

        if (_isMoving)
        {
            MoveLateral();
        }

    }

    private void MoveForward ()
    {
        _direction.z++;

        transform.position = Vector3.MoveTowards(transform.position, _direction, ForwardSpeed * Time.deltaTime);

        trail.transform.position = new Vector3(transform.position.x, 0.55f, transform.position.z);
    }

    private void HandleInput()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _targetXPosition = transform.position.x;
                _isMoving = true;

            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float touchDeltaX = touch.deltaPosition.x * Time.deltaTime;
                _targetXPosition += touchDeltaX;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _isMoving = false;
            }

        }
    }

    private void MoveLateral()
    {
            _targetXPosition = Mathf.Clamp(_targetXPosition, _leftBoundary, _rightBoundary);
            Vector3 newPosition = new Vector3(_targetXPosition, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, LateralSpeed * Time.deltaTime);
    }

}
