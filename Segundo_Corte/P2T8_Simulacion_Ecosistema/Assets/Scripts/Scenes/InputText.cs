using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{

    int _inputRabbit;
    int _inputFox;
    int _inputTime;
    string _patternRabbit = @"^[1-9]\d{0}$";
    string _patternFox = @"^[0-9]\d{0}$";
    string _patternTime = @"^[0-9]\d{1}$";

    public GameObject popupRabbit;
    public GameObject popupFox;
    public GameObject popupTime;


    private void Start() {
        this.popupRabbit.SetActive(false);
        this.popupFox.SetActive(false);
        this.popupTime.SetActive(false);
    }

    public void InputRabbit(string value)
    {
        bool isNumber = Regex.IsMatch(value, _patternRabbit);
        if (!isNumber) this.popupRabbit.SetActive(true);
        else
        {
            this._inputRabbit = int.Parse(value);
            this.popupRabbit.SetActive(false);
        }
    }

    public void InputFox(string value)
    {
        bool isNumber = Regex.IsMatch(value, _patternFox);
        if (!isNumber) this.popupFox.SetActive(true);
        else
        {
            this._inputFox = int.Parse(value);
            this.popupFox.SetActive(false);
        }
    }

    public void InputTime(string value)
    {
        bool isNumber = Regex.IsMatch(value, _patternTime);
        if (!isNumber) this.popupTime.SetActive(true);
        else
        {
            this._inputTime = int.Parse(value);
            this.popupTime.SetActive(false);
        }
    }

}
