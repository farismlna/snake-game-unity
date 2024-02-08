using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moveDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveDirection = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + moveDirection.x,
            Mathf.Round(this.transform.position.y) + moveDirection.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }


        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
            Grow();
        else if (other.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            ResetState();
        }

    }
}
