using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public void LookAtTarget() {
        Vector3 _dir = objectToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_dir, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }
    public void MoveToTarget(){
        Vector3 _tar = objectToFollow.position +
                        objectToFollow.forward * offset.z +
                        objectToFollow.right * offset.x + 
                        objectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, _tar, followSpeed*Time.deltaTime);
    }
    private void FixedUpdate() {
        LookAtTarget();
        MoveToTarget();    
    }
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 75;
}
