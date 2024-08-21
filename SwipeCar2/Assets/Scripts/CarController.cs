using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public enum State
    { 
        Move, Stop
    }

    public GameObject textGo;
    private float moveSpeed;
    private State state;
    private bool isStop;
    public System.Action moveAction;    //대리자 변수 정의 
    public System.Action moveCompleteAction;

    private void Start()
    {
        state = State.Stop;
    }

    void Update()
    {
        if (state == State.Move)
        {
            this.transform.Translate(moveSpeed, 0, 0);

            //화면을 넘어 갔다면 위치를 보정한다 
            float xPos = Mathf.Clamp(this.transform.position.x, -7.5f, 7.5f);

            //위치를 재설정한다 
            this.transform.position = new Vector3(xPos, this.transform.position.y, this.transform.position.z);

            moveSpeed *= 0.96f;
            moveAction();   //대리자 호출 
        }

        
        if (moveSpeed != 0 && Mathf.Abs(moveSpeed) <= 0.01f)
        {
            if (!isStop)
            {
                state = State.Stop;
                Debug.Log("Stop");
                isStop = true;
                moveCompleteAction();   //대리자 호출 
            }
            
        }
    }

    public void Move(InputManager.Direction direction)
    {
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.Play();

        int dir = (int)direction;
        Debug.Log($"<color=yellow>Move: {direction}, {dir}</color>");

        float speed = 0.1f;

        this.moveSpeed = dir * speed;

        Debug.Log($"<color=yellow>moveSpeed: {moveSpeed}</color>");

        this.state = State.Move;

        isStop = false;

        Debug.Log(state);

    }
}
