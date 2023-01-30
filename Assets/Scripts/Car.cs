using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float accelarate = 1f;
    [SerializeField] private float turnSpeed = 200f;

    private Vector3 totalSpeed;
    private int steerValue;

    // Update is called once per frame
    void Update()
    {
        speed += accelarate * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        totalSpeed = speed * Vector3.forward * Time.deltaTime;
        transform.Translate(totalSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
