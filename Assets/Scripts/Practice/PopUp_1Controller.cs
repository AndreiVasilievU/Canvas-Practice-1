using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_1Controller : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject pressBtnTxn;
    
    public CanvasGroup canGroup_1;
    public ButtonController[] buttons;
    
    public float scaleValue = 0f;
    private float alphaValue = 1f;

    public bool isScaleUp;
    public bool isFadeOut;
    public int numberButton;
    void Start()
    {
        isScaleUp = true;
        canGroup_1 = GetComponent<CanvasGroup>();
    }
    
    void Update()
    {
        if (isScaleUp == true)
        {
            ScaleUpPopUp();
        }

        if (isFadeOut == true)
        {
            FadeOutPopUp();
        }
    }
    
    public void FadeOutPopUp()
    {
        canGroup_1.interactable = false;
        alphaValue -= 0.6f * Time.deltaTime;
        canGroup_1.alpha = Mathf.Lerp(0, 1, alphaValue);
            
        if (alphaValue <= 0f)
        {
            isFadeOut = false;
            canGroup_1.interactable = true;
            _gameManager.isOnKey = false;
            pressBtnTxn.SetActive(true);
        }
    }

    public void ScaleUpPopUp()
    {
        if (scaleValue <= 1f)
        {
            _gameManager.isOnKey = true;
            canGroup_1.interactable = false;
            scaleValue += 0.6f * Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, scaleValue);

            if (scaleValue > 1f)
            {
                isScaleUp = false;
                canGroup_1.interactable = true;
            }
        }
    }
    
    public void OnBtnClick(int _numberButton)
    {
        numberButton = _numberButton;
        isFadeOut = true;
        canGroup_1.alpha = 1;
        alphaValue = 1f;
    }
}
