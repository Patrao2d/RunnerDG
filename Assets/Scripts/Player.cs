﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Vector3
    private Vector3 _verticalTargetPosition;

    // Vector 2
    public Vector2 firstPressPos;
    public Vector2 secondPressPos;
    public Vector2 currentSwipe;

    // Bools
    private bool _onGround;
    private bool _isSliding;
    public bool isInvulnerable;
    private bool canSwipe = true;
    [HideInInspector]public bool isShieldActive;

    // GameObjects
    public GameObject shield;

    // Floats
    private float _currentLane = 0;
    public float laneSpeed;
    public float minSwipeLength = 75f;

    // RigidBodys
    private Rigidbody _rb;

    // BoxCollider
    public BoxCollider playerCollider;

    // Layers
    public LayerMask platformLayer;

    // Enum
    private enum _Swipe { None, Up, Down, Left, Right };

    private static _Swipe swipeDirection;

    private static Player _instance;

    public static Player instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
        //_verticalTargetPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
        //_playerCollider = GetComponent<BoxCollider>();

    }

    void Update()
    {
        DetectSwipe();

        //Debug.Log(isInvulnerable);
        // works this way for some reason, TO FIX LATER
        float __extraHeight = 100f;
        _onGround = Physics.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, Vector3.down, 
            Quaternion.identity, __extraHeight, platformLayer);

        if (Input.GetKeyDown(KeyCode.I))
        {
            isInvulnerable = !isInvulnerable;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!_onGround && !_isSliding)
            {
                transform.localScale /= 1.5f;
                _isSliding = true;
                StartCoroutine(Sliding());
            }
            else
            {
                _rb.AddForce(0, -1000f * Time.fixedDeltaTime, 0, ForceMode.Impulse);
            }
        }

        //_onGround = Physics.BoxCast(playerCol)

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeLane(-1.5f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeLane(1.5f);
        }

        // works this way for some reason, TO FIX LATER
        if (Input.GetKeyDown(KeyCode.Space) && !_onGround || Input.GetKeyDown(KeyCode.W) && !_onGround)
        {
            _rb.AddForce(0, 1500f * Time.fixedDeltaTime, 0, ForceMode.Impulse);   
        }

       /* if (Input.GetKeyDown(KeyCode.LeftShift) && !_isSliding)
        {
            transform.localScale /= 1.5f;
            _isSliding = true;
            StartCoroutine(Sliding());
        }*/

    }

    void FixedUpdate()
    {
        //Debug.Log(_onGround);
        Vector3 __targetPosition = new Vector3(_verticalTargetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, __targetPosition, laneSpeed * Time.deltaTime);

    }

    private IEnumerator Sliding()
    {
        yield return new WaitForSeconds(0.3f);
        transform.localScale *= 1.5f;
        _isSliding = false;
    }


    public void ChangeLane(float direction)
    {
        float __targetLane = _currentLane + direction;
        if (__targetLane < -1.5f || __targetLane > 1.5f)
            return;
        _currentLane = __targetLane;
        _verticalTargetPosition = new Vector3((_currentLane - 0), transform.position.y, transform.position.z);
    }

    public void DetectSwipe()
    {
        if (Input.touches.Length > 0 && canSwipe == true)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            } 

            if (t.phase == TouchPhase.Moved)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    swipeDirection = _Swipe.None;
                    return;
                }

                currentSwipe.Normalize();

                
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f && !_onGround) 
                {
                    swipeDirection = _Swipe.Up;
                    Debug.Log("SWIPE UP");
                    _rb.AddForce(0, 1500f * Time.fixedDeltaTime, 0, ForceMode.Impulse);
                    canSwipe = false;
                    Invoke("SwipeCooldown", 0.1f);
                }
                else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) 
                {
                    swipeDirection = _Swipe.Down;
                    Debug.Log("SWIPE DOWN");
                    if (!_onGround && !_isSliding)
                    {
                        transform.localScale /= 1.5f;
                        _isSliding = true;
                        StartCoroutine(Sliding());
                    }
                    else
                    {
                        _rb.AddForce(0, -1000f * Time.fixedDeltaTime, 0, ForceMode.Impulse);
                    }
                    canSwipe = false;
                    Invoke("SwipeCooldown", 0.1f);
                }
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) 
                {
                    swipeDirection = _Swipe.Left;
                    Debug.Log("SWIPE LEFT");
                    ChangeLane(-1.5f);
                    canSwipe = false;
                    Invoke("SwipeCooldown", 0.2f);
                }
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) 
                {
                    swipeDirection = _Swipe.Right;
                    Debug.Log("SWIPE RIGHT");
                    ChangeLane(1.5f);
                    canSwipe = false;
                    Invoke("SwipeCooldown", 0.2f);
                }
            }
        }
        else
        {
            swipeDirection = _Swipe.None;
        }
    }

    private void SwipeCooldown()
    {
        canSwipe = true;
    }

    public void ActiveShield()
    {
        isShieldActive = true;
        shield.SetActive(true);
    }

    public void DeActiveShield()
    {
        isShieldActive = false;
        shield.SetActive(false);
    }


}
