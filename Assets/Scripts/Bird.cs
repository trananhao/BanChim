using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float xSpeed;
    public float minYspeed;
    public float maxYspeed;

    public GameObject deathVfx;

    Rigidbody2D m_rb;
    bool m_moveLeftOnStart;

    bool m_isDead;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RandomMoveDirection();
    }

    private void Update()
    {
        m_rb.velocity = m_moveLeftOnStart ? 
            new Vector2(-xSpeed, Random.Range(minYspeed, maxYspeed))
            : new Vector2(xSpeed, Random.Range(minYspeed, maxYspeed));

        Flip();
    }

    public void RandomMoveDirection()
    {
        m_moveLeftOnStart = transform.position.x > 0 ? true : false;
    }

    void Flip()
    {
        if (m_moveLeftOnStart)
        {
            if (transform.localScale.x < 0) return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x > 0) return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Die()
    {
        m_isDead = true;

        GameManager.Ins.BirdKilled++;

        Destroy(gameObject);

        if (deathVfx)
            Instantiate(deathVfx, transform.position, Quaternion.identity);

        GameGUIManager.Ins.UpdateKilledCounting(GameManager.Ins.BirdKilled);
    }
}
