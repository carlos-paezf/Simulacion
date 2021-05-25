using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class InputText : MonoBehaviour {

    private       int    _inputRabbit  = 1;
    private       int    _inputFox     = 0;
    private       int    _inputTime    = 10;
    private const string PatternRabbit = @"^[1-9]\d{0}$";
    private const string PatternFox    = @"^[0-9]\d{0}$";
    private const string PatternTime   = @"^[0-9]\d{1}$";
    private       bool   error;

    public GameObject popupRabbit;
    public GameObject popupFox;
    public GameObject popupTime;
    public GameObject popupError;


    private void Start() {
        popupRabbit.SetActive(false);
        popupFox.SetActive(false);
        popupTime.SetActive(false);
        popupError.SetActive(false);
    }

    public void InputRabbit(string value) {
        var isNumber = Regex.IsMatch(value, PatternRabbit);
        if (!isNumber) {
            popupRabbit.SetActive(true);
            error = true;
        }
        else {
            _inputRabbit = int.Parse(value);
            popupRabbit.SetActive(false);
            error = false;
        }
    }

    public void InputFox(string value) {
        var isNumber = Regex.IsMatch(value, PatternFox);
        if (!isNumber) {
            popupFox.SetActive(true); 
            error = true;
        }
        else {
            _inputFox = int.Parse(value);
            popupFox.SetActive(false);
            error = false;
        }
    }

    public void InputTime(string value) {
        var isNumber = Regex.IsMatch(value, PatternTime);
        if (!isNumber || int.Parse(value) > 25) {
            popupTime.SetActive(true);
            error = true;
        }
        else {
            _inputTime = int.Parse(value);
            popupTime.SetActive(false);
            error = false;
        }
    }

    public void BtnStart(){
        if(error) popupError.SetActive(true); 
        else {
            popupError.SetActive(false);
            SceneManager.LoadScene("Simulation");
        }
    }
}
