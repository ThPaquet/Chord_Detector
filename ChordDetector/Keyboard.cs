using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace ChordDetector
{
    public class Keyboard
    {
        public List<string>[] Keys { get; set; }

        private List<string> AddSharpKeys()
        {
            List<string> sharpKeys = new List<string>();

            sharpKeys.Add("C");
            sharpKeys.Add("C#");
            sharpKeys.Add("D");
            sharpKeys.Add("D#");
            sharpKeys.Add("E");
            sharpKeys.Add("F");
            sharpKeys.Add("F#");
            sharpKeys.Add("G");
            sharpKeys.Add("G#");
            sharpKeys.Add("A");
            sharpKeys.Add("A#");
            sharpKeys.Add("B");

            return sharpKeys;
        }

        private List<string> AddFlatKeys()
        {
            List<string> flatKeys = new List<string>();

            flatKeys.Add("C");
            flatKeys.Add("Db");
            flatKeys.Add("D");
            flatKeys.Add("Eb");
            flatKeys.Add("E");
            flatKeys.Add("F");
            flatKeys.Add("Gb");
            flatKeys.Add("G");
            flatKeys.Add("Ab");
            flatKeys.Add("A");
            flatKeys.Add("Bb");
            flatKeys.Add("B");

            return flatKeys;
        }
        public List<string>[] BuildKeyboard()
        {
            List<string>[] keyboard = new List<string>[2];

            keyboard[0] = AddFlatKeys();
            keyboard[1] = AddSharpKeys();

            return keyboard;
        }
        public Keyboard()
        {
            this.Keys = BuildKeyboard();
        }
    }
}
