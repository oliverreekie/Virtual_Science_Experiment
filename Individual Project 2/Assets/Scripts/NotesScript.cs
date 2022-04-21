using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotesScript : MonoBehaviour
{
    public TextMeshProUGUI notes;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            notes.text += " ";
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            notes.text += "\n";
        }
        else if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadEquals))
        {
            notes.text += "=";
        }
        else if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            notes.text += "+";
        }
        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            notes.text += "-";
        }
        else if (Input.GetKeyDown(KeyCode.Slash) || Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            notes.text += "/";
        }
        else if (Input.GetKeyDown(KeyCode.Asterisk) || Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            notes.text += "*";
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            notes.text = notes.text.Remove(notes.text.Length - 1);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            notes.text += "\n";
        }
        else if (Input.GetKeyDown(KeyCode.Period) || Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            notes.text += ".";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            notes.text += "a";
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            notes.text += "b";
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            notes.text += "c";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            notes.text += "d";
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            notes.text += "e";
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            notes.text += "f";
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            notes.text += "g";
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            notes.text += "h";
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            notes.text += "i";
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            notes.text += "j";
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            notes.text += "k";
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            notes.text += "l";
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            notes.text += "m";
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            notes.text += "n";
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            notes.text += "o";
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            notes.text += "p";
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            notes.text += "q";
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            notes.text += "r";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            notes.text += "s";
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            notes.text += "t";
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            notes.text += "u";
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            notes.text += "v";
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            notes.text += "w";
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            notes.text += "x";
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            notes.text += "y";
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            notes.text += "z";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            notes.text += "0";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            notes.text += "1";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            notes.text += "2";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            notes.text += "3";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            notes.text += "4";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            notes.text += "5";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            notes.text += "6";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            notes.text += "7";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            notes.text += "8";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            notes.text += "9";
        }
    }
}
