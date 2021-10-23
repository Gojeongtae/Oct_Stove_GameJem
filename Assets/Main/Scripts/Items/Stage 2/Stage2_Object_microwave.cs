using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Object_microwave : InteractiveObject
{
    [SerializeField] Image Microwave;
    public bool setactive=false;
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        setactive = true;
    }

    private void Update()
    {
        if (setactive)
        {
            Microwave.gameObject.SetActive(true);
        }
        else
            Microwave.gameObject.SetActive(false);
    }
}
