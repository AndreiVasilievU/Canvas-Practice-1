using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject popUp_1;
    [SerializeField] private GameObject popUp_2;
    [SerializeField] private GameObject pressBtnTxt;

    private PopUp_1Controller popUp_1Controller;
    private PopUp_2Controller popUp_2Controller;

    public bool isOnKey;
    public int starsCountOnPopUp_2;
    void Start()
    {
        isOnKey = true;
        pressBtnTxt.SetActive(false);
        
        popUp_1Controller = popUp_1.GetComponent<PopUp_1Controller>();
        popUp_2Controller = popUp_2.GetComponent<PopUp_2Controller>();
        
        popUp_1.transform.localScale = Vector3.zero;
        popUp_2.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (popUp_1Controller.isScaleUp == false);
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && isOnKey == false)
            {
                popUp_2Controller.ActivateStars(1);
                popUp_2Controller.isScaleUp = true;
                isOnKey = true;
                starsCountOnPopUp_2 = 1;
            }
        
            if (Input.GetKeyDown(KeyCode.Alpha2) && isOnKey == false)
            {
                popUp_2Controller.ActivateStars(2);
                popUp_2Controller.isScaleUp = true;
                isOnKey = true;
                starsCountOnPopUp_2 = 2;
            }
        
            if (Input.GetKeyDown(KeyCode.Alpha3) && isOnKey == false)
            {
                popUp_2Controller.ActivateStars(3);
                popUp_2Controller.isScaleUp = true;
                isOnKey = true;
                starsCountOnPopUp_2 = 3;
            }
        }

        if (popUp_2.activeSelf == false)
        {
            popUp_1Controller.isScaleUp = true;
            popUp_1Controller.canGroup_1.alpha = 1f;
            popUp_1Controller.scaleValue = 0f;
            popUp_2.SetActive(true);
            popUp_1Controller.buttons[popUp_1Controller.numberButton - 1].SetStars(starsCountOnPopUp_2);
            if (popUp_1Controller.numberButton < 6)
            {
                popUp_1Controller.buttons[popUp_1Controller.numberButton].UnlockBtn();
            }
        }
    }
}
