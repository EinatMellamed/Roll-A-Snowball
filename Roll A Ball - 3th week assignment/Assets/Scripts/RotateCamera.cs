using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] float speed;
    [SerializeField] float hight;
    [SerializeField] float distance;
    [SerializeField] float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(FindAngle());
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
    }


    private float FindAngle()
    {

        //between camera direction and ball velocity direction

        Vector3 targetDirection = target.GetComponent<Rigidbody>().velocity;
        Vector3 camerDirection = this.transform.rotation.eulerAngles;

        // targetDirection.x = 0f;
        //  targetDirection.z = 0f;
        //  camerDirection.x = 0f;
        // camerDirection.z = 0f;
        float targetYAngle = Mathf.Atan(targetDirection.z / targetDirection.x);
        return camerDirection.y - targetYAngle;


    }
}
