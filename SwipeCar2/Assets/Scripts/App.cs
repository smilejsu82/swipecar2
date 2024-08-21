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

        //테스트 
        //자동차와 깃발과의 거리를 출력 
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
            Debug.Log("이동 완료");
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
        //GameOver를 출력한다 
        gameDirector.UpdateUI("GameOver");
    }

}
