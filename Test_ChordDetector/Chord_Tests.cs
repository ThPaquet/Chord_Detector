using System;
using Xunit;
using ChordDetector;
using System.Collections.Generic;

namespace Test_ChordDetector
{
    public class Chord_Tests
    {
        [Fact]
        public void Test_IsNote_TrueSharp()
        {
            // Arranger

            bool isNote = false;
            bool expectedResult = true;
            string noteTest = "C#";
            

            // Agir

            isNote = Fonctions.IsNote(noteTest);

            // Auditer

            Assert.Equal(isNote, expectedResult);
        }

        [Fact]
        public void Test_IsNote_TrueFlat()
        {
            // Arranger

            bool isNote = false;
            bool expectedResult = true;
            string noteTest = "Eb";


            // Agir

            isNote = Fonctions.IsNote(noteTest);

            // Auditer

            Assert.Equal(isNote, expectedResult);
        }
        [Fact]
        public void Test_IsNote_TrueNoAlteration()
        {
            // Arranger

            bool isNote = false;
            bool expectedResult = true;
            string noteTest = "G";


            // Agir

            isNote = Fonctions.IsNote(noteTest);

            // Auditer

            Assert.Equal(isNote, expectedResult);
        }

        [Fact]
        public void Test_IsNote_FalseAnswerNoAlteration()
        {
            // Arranger

            bool isNote = false;
            bool expectedResult = false;
            string noteTest = "J";

            // Agir

            isNote = Fonctions.IsNote(noteTest);

            // Auditer

            Assert.Equal(isNote, expectedResult);
        }
        [Fact]
        public void Test_IsNote_FalseSharp()
        {
            // Arranger

            bool isNote = false;
            bool expectedResult = false;
            string noteTest = "K#";

            // Agir

            isNote = Fonctions.IsNote(noteTest);

            // Auditer

            Assert.Equal(isNote, expectedResult);
        }
        [Fact]
        public void Test_IsNote_FalseFlat()
        {
            // Arranger

            bool isNote = false;
            bool expectedResult = false;
            string noteTest = "Lb";

            // Agir

            isNote = Fonctions.IsNote(noteTest);

            // Auditer

            Assert.Equal(isNote, expectedResult);
        }


        [Fact]
        public void Test_IsFlatNote_IsNoteArgument()
        {
            // Arranger

            string testNotANote = "Tb";

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    bool isNote = Fonctions.IsFlatNote(testNotANote);
                });

        }
        [Fact]
        public void Test_IsFlatNote_True()
        {
            //Arranger

            bool isFlatNote = false;
            bool expectedResult = true;
            string noteTest = "Ab";

            // Agir

            isFlatNote = Fonctions.IsFlatNote(noteTest);

            // Auditer

            Assert.Equal(isFlatNote, expectedResult);
        }

        [Fact]
        public void Test_IsFlatNote_FalseNoAlteration()
        {
            //Arranger

            bool isFlatNote = false;
            bool expectedResult = false;
            string noteTest = "A";

            // Agir

            isFlatNote = Fonctions.IsFlatNote(noteTest);

            // Auditer

            Assert.Equal(isFlatNote, expectedResult);
        }

        [Fact]
        public void Test_IsFlatNote_FalseSharp()
        {
            //Arranger

            bool isFlatNote = false;
            bool expectedResult = false;
            string noteTest = "A#";

            // Agir

            isFlatNote = Fonctions.IsFlatNote(noteTest);

            // Auditer

            Assert.Equal(isFlatNote, expectedResult);
        }





        [Fact]
        public void Test_AddIntervalSuffix_NotesIntervalArgument()
        {
            // Arranger

            string intervalName = "Major 9";
            int NotesInterval = 9;

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalName = intervalName.AddIntervalSuffix(NotesInterval);
                });
        }

        [Fact]
        public void Test_AddIntervalSuffix_Second()
        {
            // Arranger

            string intervalName = "Major 2";
            int notesInterval = 2;
            string expectedResult = "Major 2nd";

            // Agir

            intervalName = intervalName.AddIntervalSuffix(notesInterval);

            // Auditer

            Assert.Equal(intervalName, expectedResult);
        }

        [Fact]
        public void Test_AddIntervalSuffix_Third()
        {
            // Arranger

            string intervalName = "Minor 3";
            int notesInterval = 3;
            string expectedResult = "Minor 3rd";

            // Agir

            intervalName = intervalName.AddIntervalSuffix(notesInterval);

            // Auditer

            Assert.Equal(intervalName, expectedResult);
        }

        [Fact]
        public void Test_AddIntervalSuffix_Sixth()
        {
            // Arranger

            string intervalName = "Major 6";
            int notesInterval = 6;
            string expectedResult = "Major 6th";

            // Agir

            intervalName = intervalName.AddIntervalSuffix(notesInterval);

            // Auditer

            Assert.Equal(intervalName, expectedResult);
        }


        [Fact]
        public void Test_FindNoteIndex_IsNoteArgument()
        {
            // Arranger

            string notANote = "P#";
            int noteIndex = 0;

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    noteIndex = Fonctions.FindNoteIndex(notANote);
                });
        }

        [Fact]
        public void Test_FindNoteIndex_SharpNote()
        {
            // Arranger

            string testNote = "F#";
            int noteIndex = 0;
            int expectedResult = 6;
            Keyboard keyboard = new Keyboard();

            // Agir

            noteIndex = Fonctions.FindNoteIndex(testNote);

            // Auditer

            Assert.Equal(noteIndex, expectedResult);
        }

        [Fact]
        public void Test_FindNoteIndex_FlatNote()
        {
            // Arranger

            string testNote = "Gb";
            int noteIndex = 0;
            int expectedResult = 6;
            Keyboard keyboard = new Keyboard();

            // Agir

            noteIndex = Fonctions.FindNoteIndex(testNote);

            // Auditer

            Assert.Equal(noteIndex, expectedResult);
        }

        [Fact]
        public void Test_FindNoteIndex_NoAlteration()
        {
            // Arranger

            string testNote = "G";
            int noteIndex = 0;
            int expectedResult = 7;
            Keyboard keyboard = new Keyboard();

            // Agir

            noteIndex = Fonctions.FindNoteIndex(testNote);

            // Auditer

            Assert.Equal(noteIndex, expectedResult);
        }



        [Fact]
        public void Test_CalculateSemitonesInterval_CAndG()
        {
            // Arranger

            int semitonesInterval = 0;
            int expectedResult = 7;
            List<string> interval = new List<String>();

            interval.Add("C");
            interval.Add("G");

            // Agir

            semitonesInterval = Fonctions.CalculateIntervalSemitones(interval);

            // Auditer

            Assert.Equal(semitonesInterval, expectedResult);
        }

        [Fact]
        public void Test_CalculateSemitonesInterval_GbAndFSharp()
        {
            // Arranger

            int semitonesInterval = 0;
            int expectedResult = 0;
            List<string> interval = new List<String>();

            interval.Add("Gb");
            interval.Add("F#");

            // Agir

            semitonesInterval = Fonctions.CalculateIntervalSemitones(interval);

            // Auditer

            Assert.Equal(semitonesInterval, expectedResult);
        }

        [Fact]
        public void Test_CalculateSemitonesInterval_CSharpAndBb()
        {
            // Arranger

            int semitonesInterval = 0;
            int expectedResult = 9;
            List<string> interval = new List<String>();

            interval.Add("C#");
            interval.Add("Bb");

            // Agir

            semitonesInterval = Fonctions.CalculateIntervalSemitones(interval);

            // Auditer

            Assert.Equal(semitonesInterval, expectedResult);
        }


        [Fact]
        public void Test_CalculateNotesInterval_IsNoteArgumentOne()
        {
            // Arranger

            int notesInterval = 0;
            List<string> interval = new List<String>();

            interval.Add("H");
            interval.Add("C#");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    notesInterval = Fonctions.CalculateIntervalNotes(interval);
                });
        }

        [Fact]
        public void Test_CalculateNotesInterval_IsNoteArgumentTwo()
        {
            // Arranger

            int notesInterval = 0;
            List<string> interval = new List<String>();

            interval.Add("D");
            interval.Add("K#");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    notesInterval = Fonctions.CalculateIntervalNotes(interval);
                });
        }

        [Fact]
        public void Test_CalculateNotesInterval_IsNoteArgumentBoth()
        {
            // Arranger

            int notesInterval = 0;
            List<string> interval = new List<String>();

            interval.Add("Jb");
            interval.Add("I#");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    notesInterval = Fonctions.CalculateIntervalNotes(interval);
                });
        }
        [Fact]
        public void Test_CalculateNotesInterval_CandCSharp()
        {
            // Arranger

            int notesInterval = 0;
            int expectedResult = 1;
            List<string> interval = new List<String>();

            interval.Add("C");
            interval.Add("C#");

            // Agir

            notesInterval = Fonctions.CalculateIntervalNotes(interval);

            // Auditer

            Assert.Equal(notesInterval, expectedResult);
        }

        [Fact]
        public void Test_CalculateNotesInterval_CSharpandDFlat()
        {   // En terme strictement musicaux, ce test devrait avoir tort. Toutefois, notre programme est limité.
            // Arranger

            int notesInterval = 0;
            int expectedResult = 1;
            List<string> interval = new List<String>();

            interval.Add("C#");
            interval.Add("Db");

            // Agir

            notesInterval = Fonctions.CalculateIntervalNotes(interval);

            // Auditer

            Assert.Equal(expectedResult, notesInterval);
        }


        [Fact]
        public void Test_IdentifyIntervalColor_IsNoteArgumentOne()
        {
            // Arranger

            string intervalColor = "";
            List<string> interval = new List<String>();

            interval.Add("Z");
            interval.Add("D");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalColor = Fonctions.IdentifyIntervalColor(interval);
                });
        }

        [Fact]
        public void Test_IdentifyIntervalColor_IsNoteArgumentTwo()
        {
            // Arranger

            string intervalColor = "";
            List<string> interval = new List<String>();

            interval.Add("Gb");
            interval.Add("Y");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalColor = Fonctions.IdentifyIntervalColor(interval);
                });
        }

        [Fact]
        public void Test_IdentifyIntervalColor_IsNoteArgumentBoth()
        {
            // Arranger

            string intervalColor = "";
            List<string> interval = new List<String>();

            interval.Add("Wb");
            interval.Add("T#");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalColor = Fonctions.IdentifyIntervalColor(interval);
                });
        }

        [Fact]
        public void Test_IdentifyIntervalColor_Major()
        {
            // Arranger

            string intervalColor = "";
            string expectedResult = "Major";
            List<string> interval = new List<string>();

            interval.Add("C");
            interval.Add("E");


            // Agir 

            intervalColor = Fonctions.IdentifyIntervalColor(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalColor);
        }

        [Fact]
        public void Test_IdentifyIntervalColor_Minor()
        {
            // Arranger

            string intervalColor = "";
            string expectedResult = "Minor";
            List<string> interval = new List<string>();

            interval.Add("D");
            interval.Add("Bb");


            // Agir 

            intervalColor = Fonctions.IdentifyIntervalColor(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalColor);
        }

        [Fact]
        public void Test_IdentifyIntervalColor_PerfectFifth()
        {
            // Arranger

            string intervalColor = "";
            string expectedResult = "Perfect";
            List<string> interval = new List<string>();

            interval.Add("D");
            interval.Add("A");


            // Agir 

            intervalColor = Fonctions.IdentifyIntervalColor(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalColor);
        }

        [Fact]
        public void Test_IdentifyIntervalColor_DiminishedFifth()
        {
            // Arranger

            string intervalColor = "";
            string expectedResult = "Diminished";
            List<string> interval = new List<string>();

            interval.Add("E");
            interval.Add("Bb");


            // Agir 

            intervalColor = Fonctions.IdentifyIntervalColor(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalColor);
        }

        [Fact]
        public void Test_IdentifyIntervalColor_AugmentedFourth()
        {
            // Arranger

            string intervalColor = "";
            string expectedResult = "Augmented";
            List<string> interval = new List<string>();

            interval.Add("F");
            interval.Add("B");


            // Agir 

            intervalColor = Fonctions.IdentifyIntervalColor(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalColor);
        }

        [Fact]
        public void Test_IdentifyIntervalColor_PerfectFourth()
        {
            // Arranger

            string intervalColor = "";
            string expectedResult = "Perfect";
            List<string> interval = new List<string>();

            interval.Add("E");
            interval.Add("A");


            // Agir 

            intervalColor = Fonctions.IdentifyIntervalColor(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalColor);
        }


        [Fact]
        public void Test_GetIntervalName_IsNoteArgumentOne()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";

            interval.Add("R");
            interval.Add("B");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalName = Fonctions.GetIntervalName(interval);
                });
        }

        [Fact]
        public void Test_GetIntervalName_IsNoteArgumentTwo()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";

            interval.Add("F");
            interval.Add("w");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalName = Fonctions.GetIntervalName(interval);
                });
        }

        [Fact]
        public void Test_GetIntervalName_IsNoteArgumentBoth()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";

            interval.Add("S#");
            interval.Add("Xb");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalName = Fonctions.GetIntervalName(interval);
                });
        }

        [Fact]
        public void Test_GetIntervalName_InvalidIntervalArgumentPrime()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";

            interval.Add("C");
            interval.Add("C");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalName = Fonctions.GetIntervalName(interval);
                });
        }

        [Fact]
        public void Test_GetIntervalName_InvalidIntervalArgumentAugmentedPrime()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";

            interval.Add("C");
            interval.Add("C#");

            // Agir && Auditer

            Assert.Throws<ArgumentException>(
                () =>
                {
                    intervalName = Fonctions.GetIntervalName(interval);
                });
        }

        [Fact]
        public void Test_GetIntervalName_MajorThird()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";
            string expectedResult = "Major 3rd";

            interval.Add("G");
            interval.Add("B");

            // Agir

            intervalName = Fonctions.GetIntervalName(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalName);
        }

        [Fact]
        public void Test_GetIntervalName_MinorSecond()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";
            string expectedResult = "Minor 2nd";

            interval.Add("C");
            interval.Add("Db");

            // Agir

            intervalName = Fonctions.GetIntervalName(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalName);
        }

        [Fact]
        public void Test_GetIntervalName_MajorSeventh()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";
            string expectedResult = "Major 7th";

            interval.Add("C");
            interval.Add("B");

            // Agir

            intervalName = Fonctions.GetIntervalName(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalName);
        }

        [Fact]
        public void Test_GetIntervalName_DiminishedFifth()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";
            string expectedResult = "Diminished 5th";

            interval.Add("D");
            interval.Add("Ab");

            // Agir

            intervalName = Fonctions.GetIntervalName(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalName);
        }

        [Fact]
        public void Test_GetIntervalName_AugmentedFourth()
        {
            // Arranger

            List<string> interval = new List<string>();
            string intervalName = "";
            string expectedResult = "Augmented 4th";

            interval.Add("E");
            interval.Add("A#");

            // Agir

            intervalName = Fonctions.GetIntervalName(interval);

            // Auditer

            Assert.Equal(expectedResult, intervalName);
        }
    }
}
