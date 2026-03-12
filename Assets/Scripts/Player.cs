using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;

    Vector2 minBounds;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 maxbouds;// Update is called once per frame

    Shooter shooter;


    //Animator animator;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        //animator = GetComponent<Animator>();
    }

    void Start()
    {
        InitBounds();
        //animator.SetBool("ismoving", true);
    }
    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        //Debug.Log(rawInput);
    }

    void OnAttack(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
            //Debug.Log(value);
            //Debug.Log(value.isPressed);
            //Debug.Log(shooter.isFiring);
        }
        //else
            //Debug.Log("LOL");
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Math.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxbouds.x - paddingRight);
        newPos.y = Math.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxbouds.y - paddingTop);
        transform.position = newPos;
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxbouds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
