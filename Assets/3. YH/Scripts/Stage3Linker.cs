using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct Buttons
{
    public Button ZoomParent;
    public Button CombDrawer;
    public Button PuzzleDrawer;
    public Button PlayPuzzle;
    public Button GetCuttingPicture;
    public Button LightDrawer;
}
[System.Serializable]
public struct ZoomedObjs
{
    [Header("- CombDrawer UI -")]
    public RectTransform CombDrawer;

    [Header("- Puzzle UI -")]
    public RectTransform PuzzleDrawer;
    public Image PuzzleSuccessImg;
    public Sprite PuzzleSuccess;

    [Header("- LightDrawer UI -")]
    public RectTransform LightDrawer;
}

public class Stage3Linker : MonoBehaviour
{
    public static Stage3Linker Instance { get; private set; } = null;

    public Image Bg;
    public Button Left;
    public Button Right;

    public GameObject PuzzleGame;
    public GameObject TextPrefab;
    public RectTransform Content;

    public ZoomedObjs ZoomedObjs;
    public Buttons Buttons;

    GameObject ActiveObj;

    Coroutine CMovingUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // �ݱ� ��
        Buttons.ZoomParent.onClick.AddListener(() =>
        {
            if (ActiveObj)
            {
                ActiveObj.SetActive(false);
                ZoomParent(false);
            }
        });

        // �׳� ����
        Buttons.CombDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.CombDrawer.gameObject);
        });

        // ���񼭶�
        Buttons.PuzzleDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.PuzzleDrawer.gameObject);
        });

        // ���� ����
        Buttons.PlayPuzzle.onClick.AddListener(() =>
        {
            PuzzleGame.SetActive(true);
        });

        // ����Ʈ ����
        Buttons.LightDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.LightDrawer.gameObject);
        });

        //�¿� ȭ��ǥ
        Left.onClick.AddListener(() =>
        {
            if (CMovingUI != null) StopCoroutine(CMovingUI);
            CMovingUI = StartCoroutine(UIManager.Instance.EMovingUI(Bg, Vector2.right * 960, 5, true));
        });
        Right.onClick.AddListener(() =>
        {
            if (CMovingUI != null) StopCoroutine(CMovingUI);
            CMovingUI = StartCoroutine(UIManager.Instance.EMovingUI(Bg, Vector2.left * 960, 5, true));
        });
    }

    private void ShowZoomedObj(GameObject obj)
    {
        obj.SetActive(true);
        ActiveObj = obj;
    }

    private void ZoomParent(bool value)
    {
        Buttons.ZoomParent.enabled = value;
        Buttons.ZoomParent.targetGraphic.raycastTarget = value;
    }
}
