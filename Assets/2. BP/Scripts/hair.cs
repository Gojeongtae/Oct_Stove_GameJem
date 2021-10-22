using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; } = null;
    GameObject hair;
    public int playerHair;
    private void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        // ġƮ�� �ڵ�
        if (Input.GetKeyDown(KeyCode.F2))
        {
            playerHair++;
        }
    }
}
