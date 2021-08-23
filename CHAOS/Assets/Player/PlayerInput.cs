using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI textW = null;
    [SerializeField] private TextMeshProUGUI textA = null;
    [SerializeField] private TextMeshProUGUI textD = null;

    private int keyCodeUp = (int)KeyCode.W;
    private int keyCodeLeft = (int)KeyCode.A;
    private int keyCodeRight = (int)KeyCode.D;

    private List<int> keyCodes;

    private PlayerController ctrl = null;

    private void Start()
    {
        keyCodes = new List<int>();
        keyCodes.Add((int)KeyCode.W);
        keyCodes.Add((int)KeyCode.A);
        keyCodes.Add((int)KeyCode.D);

        ctrl = GetComponent<PlayerController>();

        ResetKeys();
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown((KeyCode)keyCodeUp) && ctrl.IsGrounded())
        {
            ctrl.Jump();
        }

        if (Input.GetKey((KeyCode)keyCodeLeft))
        {
            ctrl.Left();
        }

        if (Input.GetKey((KeyCode)keyCodeRight))
        {
            ctrl.Right();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomiseKeys();
        }
    }

    public void RandomiseKeys()
    {
        List<int> checkKeyCodes = new List<int>();
        foreach (int key in keyCodes)
        {
            checkKeyCodes.Add(key);
        }

        int randInt = Random.Range(0, checkKeyCodes.Count);
        keyCodeRight = checkKeyCodes[randInt];
        checkKeyCodes.RemoveAt(randInt);

        int randIntTwo = Random.Range(0, checkKeyCodes.Count);
        keyCodeLeft = checkKeyCodes[randIntTwo];
        checkKeyCodes.RemoveAt(randIntTwo);

        int randIntThree = Random.Range(0, checkKeyCodes.Count);
        keyCodeUp = checkKeyCodes[randIntThree];
        checkKeyCodes.RemoveAt(randIntThree);

        //keyCodeRight = (int)KeyCode.W;
        //keyCodeUp = (int)KeyCode.A;
        //keyCodeLeft = (int)KeyCode.D;

        UpdateUI();
    }

    private void ResetKeys()
    {
        keyCodeUp = (int)KeyCode.W;
        keyCodeLeft = (int)KeyCode.A;
        keyCodeRight = (int)KeyCode.D;
    }

    private void UpdateUI()
    {
        switch (keyCodeRight)
        {
            case (int)KeyCode.W:
                textW.text = ">";
                break;
            case (int)KeyCode.A:
                textA.text = ">";
                break;
            case (int)KeyCode.D:
                textD.text = ">";
                break;
        }

        switch (keyCodeLeft)
        {
            case (int)KeyCode.W:
                textW.text = "<";
                break;
            case (int)KeyCode.A:
                textA.text = "<";
                break;
            case (int)KeyCode.D:
                textD.text = "<";
                break;
        }

        switch (keyCodeUp)
        {
            case (int)KeyCode.W:
                textW.text = "^";
                break;
            case (int)KeyCode.A:
                textA.text = "^";
                break;
            case (int)KeyCode.D:
                textD.text = "^";
                break;
        }
    }
}
