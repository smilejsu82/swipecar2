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
    public System.Action moveAction;    //�븮�� ���� ���� 
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

            //ȭ���� �Ѿ� ���ٸ� ��ġ�� �����Ѵ� 
            float xPos = Mathf.Clamp(this.transform.position.x, -7.5f, 7.5f);

            //��ġ�� �缳���Ѵ� 
            this.transform.position = new Vector3(xPos, this.transform.position.y, this.transform.position.z);

            moveSpeed *= 0.96f;
            moveAction();   //�븮�� ȣ�� 
        }

        
        if (moveSpeed != 0 && Mathf.Abs(moveSpeed) <= 0.01f)
        {
            if (!isStop)
            {
                state = State.Stop;
                Debug.Log("Stop");
                isStop = true;
                moveCompleteAction();   //�븮�� ȣ�� 
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
