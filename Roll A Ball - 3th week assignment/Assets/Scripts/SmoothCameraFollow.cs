using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Transform target;
    [SerializeField] float smoothTime;
    [SerializeField] Vector3 currentVelocity = Vector3.zero;
    [SerializeField] List<Vector3> cameraPositions = new List<Vector3>();
    private int currentIndex;
    [SerializeField] Rigidbody rb;
    [SerializeField] float _cameraPositionOffset;
    public bool switchCamera;
    [SerializeField] float elapsedTime;

    //the camera has 4 optional positions around the ball (every 90 degrees)
    //the player can choose from which one to look at the ball.
    //the transformation between the position is smooth (with lerp) 

  

    private void Start()
    {
        
        offset = transform.position - target.position;

        rb = GetComponent<Rigidbody>();

        // positions initialization
        cameraPositions.Add( Vector3.forward * _cameraPositionOffset);
        cameraPositions.Add( Vector3.right * _cameraPositionOffset);
        cameraPositions.Add( - Vector3.forward * _cameraPositionOffset);
        cameraPositions.Add( - Vector3.right * _cameraPositionOffset);

        //ovveride the y position(with foreach)

        transform.position = cameraPositions[0];
    }
    private void Update()
    {
        transform.LookAt(target);
        // transform.position = target.position + offset;
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(!switchCamera)
            {
                switchCamera = true;
                elapsedTime = 0;
            
            }
           
          

            

           

        }
        if(switchCamera)
        {
           // offset = cameraPositions[(currentIndex + 1) % cameraPositions.Count];
           offset = Vector3.Lerp(cameraPositions[currentIndex], cameraPositions[(currentIndex + 1) % cameraPositions.Count], elapsedTime/ smoothTime);

            elapsedTime += Time.deltaTime;
            if (elapsedTime <= smoothTime)
            {
                switchCamera = false;
                currentIndex = (currentIndex + 1) % cameraPositions.Count;

            }
        }
        else
        {

           
            offset = cameraPositions[currentIndex];
        }

        transform.position = offset + new Vector3 (target.position.x, transform.position.y, target.position.z); 

    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(target.position + offset);

    }
    private void LateUpdate()
    {
       
      
         //  Vector3 tagetPosition = target.position + offset;
      //  transform.position = Vector3.SmoothDamp(transform.position, tagetPosition, ref currentVelocity, smoothTime);

     
    }
}

