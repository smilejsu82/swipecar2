using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class App : MonoBehaviour
{
    public InputManager inputManager;
    public CarController carController;
    public Transform flagTrans;
    public GameDirector gameDirector;

    public void Start()
    {

        //�׽�Ʈ 
        //�ڵ����� ��߰��� �Ÿ��� ��� 
        float distanceX = CalcDistance();

        if (distanceX < 0)
        {
            Debug.Log("GameOver");
            this.GameOver();
        }
        else 
        {
            Debug.Log(distanceX);
            this.UpdateDistanceUI(distanceX);
        }




        this.inputManager.swipeAction = (direction) => {

            Debug.Log(direction);

            carController.Move(direction);

        };

        carController.moveAction = () => {

            float distanceX = CalcDistance();

            this.UpdateDistanceUI(distanceX);

        };

        carController.moveCompleteAction = () => {
            Debug.Log("�̵� �Ϸ�");
        };
    }


    private float CalcDistance() 
    {
        Vector3 carPos = carController.gameObject.transform.position;
        Vector3 flagPos = this.flagTrans.position;

        float distanceX = flagPos.x - carPos.x;

        return distanceX;
    }

    private void UpdateDistanceUI(float distanceX)
    {
        gameDirector.UpdateUI(distanceX);
    }

    private void GameOver()
    {
        //GameOver�� ����Ѵ� 
        gameDirector.UpdateUI("GameOver");
    }

}
