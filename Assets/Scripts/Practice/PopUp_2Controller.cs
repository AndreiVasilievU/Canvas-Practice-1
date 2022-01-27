using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_2Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] fullStars;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject pressBtnTxn;

    private CanvasGroup canGroup_2;

    public bool isScaleUp;
    public bool isFadeOut;
    
    private float scaleValue;
    private float alphaValue = 1f;
    void Start()
    {
        canGroup_2 = GetComponent<CanvasGroup>();
        
        foreach (var VARIABLE in fullStars)
        {
            VARIABLE.SetActive(false);
        }
    }

    // Update is called once per frame
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

    public void ScaleUpPopUp()
    {
        if (scaleValue <= 1f)
        {
            pressBtnTxn.SetActive(false);
            canGroup_2.interactable = false;
            alphaValue = 1f;
            canGroup_2.alpha = 1f;
            
            scaleValue += 0.6f * Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, scaleValue);

            if (scaleValue > 1f)
            {
                isScaleUp = false;
                canGroup_2.interactable = true;
            }
        }
    }

    public void FadeOutPopUp()
    {
        canGroup_2.interactable = false;
        alphaValue -= 0.6f * Time.deltaTime;
        canGroup_2.alpha = Mathf.Lerp(0, 1, alphaValue);
            
        if (alphaValue <= 0f)
        {
            isFadeOut = false;
            canGroup_2.interactable = true;
            gameObject.SetActive(false);
            scaleValue = 0;
            transform.localScale = Vector3.zero;
        }
    }
    
    public void ActivateStars(int amount)
    {
        for (int i = 0; i < fullStars.Length; i++)
        {
            fullStars[i].SetActive(i < amount);
        }
    }
    
    public void OnBtnClick()
    {
        isFadeOut = true;
    }
}
