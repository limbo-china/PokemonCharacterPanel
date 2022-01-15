using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewSwitchHandler : MonoBehaviour
{
    enum Status { Left =0 , Right =1};
    public Button largeButton;
    public Button smallButton;

    public Transform largeOnBackground;
    public Transform smallOnBackground;

    public Transform smallPreview;
    public Transform largePreview;

    Status switchStatus = Status.Left; 
    // Start is called before the first frame update
    void Start()
    {
        UpdateSwitchStatus(switchStatus);
        smallButton.onClick.AddListener(LeftOnClick);
        largeButton.onClick.AddListener(RightOnClick);
    }

    void UpdateSwitchStatus(Status s)
    {
        smallOnBackground.gameObject.SetActive(s == Status.Left ? true : false);
        largeOnBackground.gameObject.SetActive(s == Status.Left ? false : true);
        smallPreview.gameObject.SetActive(s == Status.Left ? true : false);
        largePreview.gameObject.SetActive(s == Status.Left ? false : true);
    }
    
    void LeftOnClick()
    {
        switchStatus = Status.Left;
        UpdateSwitchStatus(switchStatus);
    }
    void RightOnClick()
    {
        switchStatus = Status.Right;
        UpdateSwitchStatus(switchStatus);
    }
}
