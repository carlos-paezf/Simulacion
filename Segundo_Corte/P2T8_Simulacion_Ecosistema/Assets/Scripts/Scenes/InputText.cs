using UnityEngine;
using System.Text.RegularExpressions;

public class InputText : MonoBehaviour {

    private       int    _inputRabbit;
    private       int    _inputFox;
    private       int    _inputTime;
    private const string PatternRabbit = @"^[1-9]\d{0}$";
    private const string PatternFox    = @"^[0-9]\d{0}$";
    private const string PatternTime   = @"^[0-9]\d{1}$";

    public GameObject popupRabbit;
    public GameObject popupFox;
    public GameObject popupTime;


    private void Start() {
        popupRabbit.SetActive(false);
        popupFox.SetActive(false);
        popupTime.SetActive(false);
    }

    public void InputRabbit(string value) {
        var isNumber = Regex.IsMatch(value, PatternRabbit);
        if (!isNumber) popupRabbit.SetActive(true);
        else {
            _inputRabbit = int.Parse(value);
            popupRabbit.SetActive(false);
        }
    }

    public void InputFox(string value) {
        var isNumber = Regex.IsMatch(value, PatternFox);
        if (!isNumber) popupFox.SetActive(true);
        else {
            _inputFox = int.Parse(value);
            popupFox.SetActive(false);
        }
    }

    public void InputTime(string value) {
        var isNumber = Regex.IsMatch(value, PatternTime);
        if (!isNumber || int.Parse(value) > 25) popupTime.SetActive(true);
        else {
            _inputTime = int.Parse(value);
            popupTime.SetActive(false);
        }
    }

}
