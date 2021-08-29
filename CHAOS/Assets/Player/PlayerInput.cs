using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Sprite runeUp = null;
    [SerializeField] private Sprite runeLeft = null;
    [SerializeField] private Sprite runeRight = null;
    [SerializeField] private Image imgW = null;
    [SerializeField] private Image imgA = null;
    [SerializeField] private Image imgD = null;
    [SerializeField] private Image runeW = null;
    [SerializeField] private Image runeA = null;
    [SerializeField] private Image runeD = null;

    private int keyCodeUp = (int)KeyCode.W;
    private int keyCodeLeft = (int)KeyCode.A;
    private int keyCodeRight = (int)KeyCode.D;

    private int keyCodeUpAlt = (int)KeyCode.UpArrow;
    private int keyCodeLeftAlt = (int)KeyCode.LeftArrow;
    private int keyCodeRightAlt = (int)KeyCode.RightArrow;

    private List<int> keyCodes;
    private List<int> keyCodesAlt;

    private PlayerController ctrl = null;
    private ChaosShader shad = null;

    private void Start()
    {
        keyCodes = new List<int>();
        keyCodes.Add((int)KeyCode.W);
        keyCodes.Add((int)KeyCode.A);
        keyCodes.Add((int)KeyCode.D);

        keyCodesAlt = new List<int>();
        keyCodesAlt.Add((int)KeyCode.UpArrow);
        keyCodesAlt.Add((int)KeyCode.LeftArrow);
        keyCodesAlt.Add((int)KeyCode.RightArrow);

        ctrl = GetComponent<PlayerController>();
        shad = GetComponentInChildren<ChaosShader>();

        ResetKeys();
        UpdateUI();

        GameManager.Instance.Newgame.AddListener(NewGame);
    }

    void NewGame()
    {
        ResetKeys();
    }
    void Update()
    {
        if (Input.GetKeyDown((KeyCode)keyCodeUp) || Input.GetKeyDown((KeyCode)keyCodeUpAlt))
        {
            if(ctrl.IsGrounded())
                ctrl.Jump(ctrl.jumpForce);
        }

        if (Input.GetKey((KeyCode)keyCodeLeft) || Input.GetKey((KeyCode)keyCodeLeftAlt))
        {
            ctrl.Left();
        }

        if (Input.GetKey((KeyCode)keyCodeRight) || Input.GetKey((KeyCode)keyCodeRightAlt))
        {
            ctrl.Right();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<ChaosTimer>().SpawnWave();
        }
    }

    public void RandomiseKeys()
    {
        StartCoroutine(shad.Shift());

        StartCoroutine(runeW.GetComponent<ChaosShader>().Shift());
        StartCoroutine(runeA.GetComponent<ChaosShader>().Shift());
        StartCoroutine(runeD.GetComponent<ChaosShader>().Shift());

        List<int> checkKeyCodes = new List<int>();
        foreach (int key in keyCodes)
        {
            checkKeyCodes.Add(key);
        }

        List<int> checkKeyCodesAlt = new List<int>();
        foreach (int key in keyCodesAlt)
        {
            checkKeyCodesAlt.Add(key);
        }

        int randInt = Random.Range(0, checkKeyCodes.Count);
        keyCodeRight = checkKeyCodes[randInt];
        keyCodeRightAlt = checkKeyCodesAlt[randInt];
        checkKeyCodesAlt.RemoveAt(randInt);
        checkKeyCodes.RemoveAt(randInt);

        int randIntTwo = Random.Range(0, checkKeyCodes.Count);
        keyCodeLeft = checkKeyCodes[randIntTwo];
        keyCodeLeftAlt = checkKeyCodesAlt[randIntTwo];
        checkKeyCodesAlt.RemoveAt(randIntTwo);
        checkKeyCodes.RemoveAt(randIntTwo);

        int randIntThree = Random.Range(0, checkKeyCodes.Count);
        keyCodeUp = checkKeyCodes[randIntThree];
        keyCodeUpAlt = checkKeyCodesAlt[randIntThree];
        checkKeyCodesAlt.RemoveAt(randIntThree);
        checkKeyCodes.RemoveAt(randIntThree);

        UpdateUI();
    }

    private void ResetKeys()
    {
        keyCodeUp = (int)KeyCode.W;
        keyCodeLeft = (int)KeyCode.A;
        keyCodeRight = (int)KeyCode.D;

        keyCodeUpAlt = (int)KeyCode.UpArrow;
        keyCodeLeftAlt = (int)KeyCode.LeftArrow;
        keyCodeRightAlt = (int)KeyCode.RightArrow;
    }

    private void UpdateUI()
    {
        switch (keyCodeRight)
        {
            case (int)KeyCode.W:
                imgW.sprite = runeRight;
                break;
            case (int)KeyCode.A:
                imgA.sprite = runeRight;
                break;
            case (int)KeyCode.D:
                imgD.sprite = runeRight;
                break;
        }

        switch (keyCodeLeft)
        {
            case (int)KeyCode.W:
                imgW.sprite = runeLeft;
                break;
            case (int)KeyCode.A:
                imgA.sprite = runeLeft;
                break;
            case (int)KeyCode.D:
                imgD.sprite = runeLeft;
                break;
        }

        switch (keyCodeUp)
        {
            case (int)KeyCode.W:
                imgW.sprite = runeUp;
                break;
            case (int)KeyCode.A:
                imgA.sprite = runeUp;
                break;
            case (int)KeyCode.D:
                imgD.sprite = runeUp;
                break;
        }
    }
}
