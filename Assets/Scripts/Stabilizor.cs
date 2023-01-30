using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizor : MonoBehaviour
{
    [SerializeField] float smooth = 1f;


    private float currentXRotation;
    private float currentYRotation;
    private float currentZRotation;

    Quaternion target;


    // Start is called before the first frame update
    void Start()
    {
        currentXRotation = transform.eulerAngles.x;
        currentYRotation = transform.eulerAngles.y;
        currentZRotation = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation != target)
        {
            target = Quaternion.Euler(currentXRotation, transform.eulerAngles.y, currentZRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
    }
}
