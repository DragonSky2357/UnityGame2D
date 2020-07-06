using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour { 

    //Floating point variable to store the player's movement speed
    //플레이어의 이동속도를 저장하기 위한 실수변수
    public float speed;

    //Store a reference to the UI Text component which will display the number of pickups collected.
    //코인의 갯수를 표시하는 UI
    public Text countText;

    //Store a reference to the UI Text component which will display the 'You win' message.
    //승리를 표시하는 UI
    public Text winText;            

    //Store a reference to the Rigidbody2D component required to use 2D Physics.
    //2D 물리 컴포넌트(Rigidbody2D)를 사용 및 저장하기 위한 변수
    private Rigidbody2D rb2d;

    //Integer to store the number of pickups collected so far.
    //코인의 갯수 카운트를 위한 변수
    private int count;
    //Use this for initalization
    //초기화
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        //Rigidbody2D를 가져와 접근가능
        rb2d = GetComponent<Rigidbody2D>();
        //Initialize count to zero.
        //count값 0으로 초기화
        count = 0;

        //Initialze winText to a blank string since we haven't won yet at beginning.
        //승리 UI 공백으로 초기화
        winText.text = "";

        //Call our SetCountText function which will update the text with the current value for count.
        //코인 갯수 업데이트 
        SetCountText();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    // 물리적인 상황이 각각의 프레임에 따라서 다음 함수 호출
    private void FixedUpdate() {
        //Store the current horizontal input in the float moveHorizontal.
        //현재 입력받은 수평값(x축) 저장
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        //현재 입력받은 수평값(y축) 저장
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        //이동하기 위해 2개의 저장된 변수를 이용하여 Vector2변수를 생성
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //플레이어를 이동하려면 Riddlebody2D rb2D 이동에 속도를 곱한뒤 AddForce함수 호출
        rb2d.AddForce(movement * speed);
    }
    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    //객체와 겹칠때마다 즉시 실행
    void OnTriggerEnter2D(Collider2D other) {
        //Check the provide Collider2D parameter other to see if it is tagged "PickUp", if it is...
        //other로 충돌이 일어난 객체가 PickUp이면 그 객체를 비활성화한다.
        if (other.gameObject.CompareTag("PickUp"))
            other.gameObject.SetActive(false);

        //Add one to the current value of our count variable.
        //코인 갯수 증가
        count++;

        //Update the currently displayed count by calling the SetCountText function.
        //코인 갯수 UI 업데이트
        SetCountText();
    }

    private void SetCountText() {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        //코인 갯수 업데이트
        countText.text = "Count: " + count.ToString();

        //Check if we've collected all 12 pickups. If we have...
        //코인 갯수가 12개가 넘기면
        if (count >= 12)
            //... then set the text property of our winText object to "You win!"
            //승리 택스트 출력
            winText.text = "You win!";
    }
}
