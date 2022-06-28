using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; 
    private Vector3 offset;
    [SerializeField] private float lerpTime;
    //sound
    private AudioSource playerAudio;
    void Start()
    {
        offset = transform.position - player.transform.position;
        playerAudio = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        Vector3 newPos=Vector3.Lerp(transform.position, player.transform.position+offset, lerpTime*Time.deltaTime);
        transform.position = newPos;
        playerAudio.Play();
    }
}
