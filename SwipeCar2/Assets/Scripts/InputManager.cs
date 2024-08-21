using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //열거 형식 정의 
    public enum Direction
    { 
        Left = -1, Right = 1
    }

    //대리자 변수 정의 
    public System.Action<Direction> swipeAction;

    private Vector3 startPos;

    void Update()
    {
        bool isDown = Input.GetMouseButtonDown(0);

        if (isDown)
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 endPos = Input.mousePosition;

            float dirX = endPos.x - startPos.x;

            if (dirX > 0)
            {
                //대리자 호출
                this.swipeAction(Direction.Right);
            }
            else if (dirX < 0)
            {
                this.swipeAction(Direction.Left);
            }

        }
    }
}
