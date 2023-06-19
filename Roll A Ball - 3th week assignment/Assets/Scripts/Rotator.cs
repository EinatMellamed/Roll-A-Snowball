using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{

    [SerializeField] Transform snowFlake;
    public float speedZ;
    public float speedX;
    public float speedY;
    public float localMoveX;
    public float localMoveY;
    public float localMoveZ;
    public float duration;
    public float localMoveDuration;
    public Ease ease;

    private void Start()
    {
       snowFlake.transform.DOLocalMove(new Vector3(localMoveX,localMoveY,localMoveZ),localMoveDuration).SetEase(ease).SetLoops(-1,LoopType.Yoyo);
    }
    void Update()
    {
         transform.Rotate(new Vector3(speedX, speedY, speedZ) * Time.deltaTime);
        
    
    }
}
