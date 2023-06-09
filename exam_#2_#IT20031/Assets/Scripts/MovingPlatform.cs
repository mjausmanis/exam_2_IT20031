using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public GameObject[] points;
    [SerializeField] private float speed = 1f;

    private int currentTarget = 0;
    private float t = 0f;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 nextPosition = Vector3.Lerp(points[currentTarget].transform.position, points[(currentTarget + 1) % points.Length].transform.position, t);
        transform.position = nextPosition;

        t += Time.deltaTime * speed;

        if (t >= 1f)
        {
            t = 0f;
            currentTarget = (currentTarget + 1) % points.Length;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Enter trigger");
            player.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Exit Trigger");
            player.parent = null;
        }
    }
}
