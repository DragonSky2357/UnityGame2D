using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Public  variable to store a reference to the player game object
    //player game object를 참조하기 위한 변수 선언
    public GameObject player;

    //Private variable to store the offset distance between the player and camera
    //플레이어와 카메라간의 거리폭을 담는 변수
    private Vector3 offset;

    //Use this for initialization
    //초기화
    void Start() {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //플레이어의 위치와 카메라의 위치 사이의 거리를 계산하여 저장 (distance = V2-V1)
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    // 각 프레임 처리후 호출
    void LateUpdate() {
        // Set the position of the camera's transform to be the same as the player's, but offset by the caculated offset distance.
        // 거리사이를 계산한뒤 플레이어와 카메라의 위치를 설정
        transform.position = player.transform.position + offset;
    }
}
