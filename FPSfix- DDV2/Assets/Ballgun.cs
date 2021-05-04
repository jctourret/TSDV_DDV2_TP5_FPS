using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballgun : MonoBehaviour
{
    public GameObject ball;
    Vector3 launchForce = new Vector3 (0,0,50.0f);
    private void OnEnable()
    {
        Player_Character.shootEquippedGun += shootBall;
    }
    private void OnDisable()
    {
        Player_Character.shootEquippedGun -= shootBall;
    }
    void shootBall()
    {
        GameObject gO = Instantiate(ball,transform.position,Quaternion.identity);
        Rigidbody rb = gO.GetComponent<Rigidbody>();
        rb.AddForce(transform.TransformDirection(launchForce),ForceMode.Impulse);
    }
}
