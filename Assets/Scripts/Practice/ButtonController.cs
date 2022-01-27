using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject[] starsFull;
    [SerializeField] private Image closedImage;
    [SerializeField] private Color[] colors;
    [SerializeField] private bool isFirstBtn;

    private Button button;
    private int _countFullStars;
    
    public Image buttonImage;
    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        _countFullStars = 0;
        
        if (isFirstBtn == false)
        {
            buttonImage.color = colors[1];
            button.interactable = false;
        }

        foreach (var VARIABLE in starsFull)
        {
            VARIABLE.SetActive(false);
        }
    }

    public void UnlockBtn()
    {
        closedImage.gameObject.SetActive(false);
        buttonImage.color = colors[0];
        button.interactable = true;
    }

    public void SetStars(int _starsCount)
    {
        if (_countFullStars > _starsCount) return;
        
        for (int i = 0; i < _starsCount; i++)
        {
            starsFull[i].SetActive(true);
            _countFullStars += 1;
        }
    }
}
