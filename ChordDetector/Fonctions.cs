using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static ChordDetector.Keyboard;

namespace ChordDetector
{
    public static class Fonctions
    {
        public static bool IsNote(this string p_note)
        {
            bool isNote = false;
            Keyboard keyboard = new Keyboard();

            if (keyboard.Keys[0].Contains(p_note) || keyboard.Keys[1].Contains(p_note))
            {
                isNote = true;
            }

            return isNote;
        }
        public static bool IsFlatNote(this string p_note)
        {
            if (p_note.IsNote() == false)
            {
                throw new ArgumentException("Parameter entered is note a valid note.", "p_note");
            }

            bool isflatNote = false;

            if (p_note.Length == 2)

                if (p_note[1].ToString() == "b")
                {
                    isflatNote = true;
                }

            return isflatNote;
        }
        /*public static string ConvertFlatNote(string p_note)
        {
            if (p_note.IsNote() == false)
            {
                throw new ArgumentException("Entered parameter is not a valid note.", "p_note");
            }

            string convertedNote = "";
            Keyboard keyboard = new Keyboard();

            if (p_note.IsFlatNote())
            {
                int noteIndex = keyboard.Keys.IndexOf(p_note[0].ToString());

                Console.Out.WriteLine(noteIndex);

                if (noteIndex == 0)
                {
                    convertedNote = keyboard.Keys[11];
                }

                else
                {
                    convertedNote = keyboard.Keys[noteIndex -1];
                }
            };

            return convertedNote;
        }*/
        public static string AddIntervalSuffix(this string p_intervalName, int p_notesInterval)
        {
            if (p_notesInterval < 2 || p_notesInterval > 7)
            {
                throw new ArgumentException("The interval must be between Second and Seventh", "p_notesInterval");
            }

            switch (p_notesInterval) // split this into another function
            {
                case 2:
                    p_intervalName += "nd";
                    break;

                case 3:
                    p_intervalName += "rd";
                    break;

                default:
                    p_intervalName += "th";
                    break;
            }

            return p_intervalName;
        }
        public static int FindNoteIndex(string p_note)
        {
            if (p_note.IsNote() == false)
            {
                throw new ArgumentException("Parameter must be a valid note.", "p_note");
            }

            Keyboard keyboard = new Keyboard();
            int noteIndex = 0;

            if (p_note.IsFlatNote())
            {
                noteIndex = keyboard.Keys[0].IndexOf(p_note);
            }

            else
            {
                noteIndex = keyboard.Keys[1].IndexOf(p_note);
            }

            return noteIndex;
        }
        public static int CalculateIntervalSemitones(List<string> p_interval)
        {
            if (p_interval[0].IsNote() == false || p_interval[1].IsNote() == false)
            {
                throw new ArgumentException("List must contain valid notes.", "p_interval");
            }

            int semitones = 0;
            int baseNoteIndex = 0;
            int highNoteIndex = 0;

            baseNoteIndex = FindNoteIndex(p_interval[0]);
            highNoteIndex = FindNoteIndex(p_interval[1]);

            semitones = highNoteIndex - baseNoteIndex;

            return semitones;
        }
        public static int CalculateIntervalNotes(List<string> p_interval)
        {
            if (p_interval[0].IsNote() == false || p_interval[1].IsNote() == false)
            {
                throw new ArgumentException("List must contain valid notes.", "p_interval");
            }

            Keyboard keyboard = new Keyboard();
            int interval = 1; // La plus petite intervale (unison) se nomme Prime
            int baseNoteIndex = 0;
            int highNoteIndex = 0;

            baseNoteIndex = FindNoteIndex(p_interval[0].ToString());
            highNoteIndex = FindNoteIndex(p_interval[1].ToString());

            Console.Out.WriteLine(baseNoteIndex);
            Console.Out.WriteLine(highNoteIndex);

            for (int currentNote = baseNoteIndex; currentNote < highNoteIndex; currentNote++)
            {
                if (keyboard.Keys[0].Contains(p_interval[0]) && keyboard.Keys[0].Contains(p_interval[1]))
                {
                    if (keyboard.Keys[0][currentNote][0] != keyboard.Keys[0][currentNote + 1][0])
                    {
                        interval += 1;
                    }
                }

                else
                {
                    if (keyboard.Keys[1][currentNote][0] != keyboard.Keys[1][currentNote + 1][0])
                    {
                        interval += 1;
                    }
                }
            }


            return interval;
        }
        public static string IdentifyIntervalColor(List<string> p_interval)
        {
            if (p_interval[0].IsNote() == false || p_interval[1].IsNote() == false)
            {
                throw new ArgumentException("List must contain valid notes.", "p_interval");
            }

            string color = "";
            int semitonesInterval = 0;
            int notesInterval = 0;

            semitonesInterval = CalculateIntervalSemitones(p_interval);
            notesInterval = CalculateIntervalNotes(p_interval);

            Console.Out.WriteLine(semitonesInterval);
            Console.Out.WriteLine(notesInterval);

            if (notesInterval == 1)
            {
                if (semitonesInterval % 2 == 0)
                {
                    color = "Perfect";
                }

                else
                {
                    color = "Augmented";
                }

            }

            else if (notesInterval == 2 || notesInterval == 3)
            {
                if (semitonesInterval % 2 == 0)
                {
                    color = "Major";
                }

                else
                {
                    color = "Minor";
                }
            }

            else if (notesInterval == 4)
            {
                if (semitonesInterval % 2 == 0)
                {
                    color = "Augmented";
                }

                else
                {
                    color = "Perfect";
                }
            }

            else if (notesInterval == 5)
            {
                if (semitonesInterval % 3 == 0)
                {
                    color = "Diminished";
                }

                else if (semitonesInterval % 3 == 1)
                {
                    color = "Perfect";
                }

                else
                {
                    color = "Augmented";
                }
            }

            else
            {
                if (notesInterval % 2 == 0)
                {
                    color = "Minor";
                }

                else 
                {
                    color = "Major";
                }
            }

            return color;
        }
        public static string GetIntervalName(List<string> p_interval)
        {
            if (p_interval[0].IsNote() == false || p_interval[1].IsNote() == false)
            { 
                throw new ArgumentException("List must contain valid notes.", "p_interval");
            }
            string intervalName = "";

            intervalName += IdentifyIntervalColor(p_interval);
            intervalName += " " + CalculateIntervalNotes(p_interval);
            intervalName = intervalName.AddIntervalSuffix(CalculateIntervalNotes(p_interval));

            return intervalName;
        }
    }
}
