using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOController : MonoBehaviour
{
    public float speed = 5f;
    private bool isMovingRight = true;
    private float leftBound = -10f;
    private float rightBound = 10f;

    private float destroyDelay = 0.5f;
    private float animationIntervalMin = 5f;
    private float animationIntervalMax = 10f;

    private Coroutine destructionCoroutine;
    private Coroutine animationCoroutine;

    private Animator ufoAnimator;

    void Start()
    {
        ufoAnimator = GetComponent<Animator>();
        StartAnimationCoroutine();
    }

    void Update()
    {
        MoveUFO();
    }

    public void Initialize(bool spawnFromLeft)
    {
        isMovingRight = spawnFromLeft;
        if (spawnFromLeft)
        {
            transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
        else
        {
            transform.position = new Vector3(rightBound, transform.position.y, 0);
        }
    }

    void MoveUFO()
    {
        Vector3 movement = isMovingRight ? Vector3.right : Vector3.left;
        transform.Translate(movement * Time.deltaTime * speed);

        if (isMovingRight && transform.position.x >= rightBound)
        {
            destructionCoroutine = StartCoroutine(DestroyAfterDelay());
        }
        else if (!isMovingRight && transform.position.x <= leftBound)
        {
            destructionCoroutine = StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    void StartAnimationCoroutine()
    {
        animationCoroutine = StartCoroutine(PlayAnimationWithInterval());
    }

    IEnumerator PlayAnimationWithInterval()
    {
        while (true)
        {
            float interval = Random.Range(animationIntervalMin, animationIntervalMax);
            ufoAnimator.Play("abduction");
            yield return new WaitForSeconds(interval);
        }
    }

}

