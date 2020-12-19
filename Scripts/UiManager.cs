using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button _game;
    [SerializeField] private InputField _inputRed;
    [SerializeField] private InputField _inputBlack;
    [SerializeField] private Text _winText;
    void Start()
    {
        _game.onClick.AddListener(() =>
        {
            string textRed = _inputRed.text;
            double.TryParse(textRed,out double chanceRed);

            string textBlack = _inputBlack.text;
            double.TryParse(textBlack, out double chanceBlack);

            if (chanceBlack == 0 || chanceRed == 0)
            {
                _winText.text = "Одно из значений заполнено некорректно или равно нулю";
                return;
            }

            double[] chances = new[] { chanceRed, chanceBlack };
            int value = Roulette.GetRoulette(chances);
            
            if (value == 0)
            {
                _winText.text = "Выпало красное";
            }
            else
            {
                _winText.text = "Выпало черное";
            }
        });
    }

}
