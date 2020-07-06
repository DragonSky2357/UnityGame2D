using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Update is called every frame
    void Update() {
        //Rotate thet transform of the game object this is attached to by 45 degrees, taking into account the time elapsed since last frame.
        //매프레임 마다 마지막 프레임으로 부터 45도씩 game object에 추가한다.
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
