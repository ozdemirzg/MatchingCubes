using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] float turnSpeed=7;
    [SerializeField] float playerSpeed = 4;
    [SerializeField] private float horizontalLimit=4;
    //sound
    private AudioSource playerAudio;

    private void Start()
    {
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        float newZ;
        horizontalInput = Input.GetAxis("Horizontal");
        newZ=transform.position.z-horizontalInput*turnSpeed*Time.deltaTime;
        newZ=Mathf.Clamp(newZ,-horizontalLimit,horizontalLimit);
        transform.position=new Vector3(transform.position.x,transform.position.y,newZ); 
      
        transform.Translate(Vector3.right*Time.deltaTime*playerSpeed);
    }


}
