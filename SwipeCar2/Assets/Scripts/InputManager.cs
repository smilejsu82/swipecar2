using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //���� ���� ���� 
    public enum Direction
    { 
        Left = -1, Right = 1
    }

    //�븮�� ���� ���� 
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
                //�븮�� ȣ��
                this.swipeAction(Direction.Right);
            }
            else if (dirX < 0)
            {
                this.swipeAction(Direction.Left);
            }

        }
    }
}
