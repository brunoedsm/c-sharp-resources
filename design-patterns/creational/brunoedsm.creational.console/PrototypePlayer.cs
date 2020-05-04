/*
    Scenario to use prototype:
    A chord creator
    For better reference, please visit https://www.dofactory.com/net/design-patterns
*/

using System;
using System.Collections.Generic;

namespace brunoedsm.creational.console
{

    public static class PrototypePlayer
    {
        public static void PlayExample()
        {
            ChordManager manager = new ChordManager();

            manager["major"] = new Chord(1,3,5);
            manager["sus2"] = new Chord(1,2,5);
            manager["sus4"] = new Chord(1,4,5);

            Chord chordOne  = manager["major"].Clone() as Chord;
            Chord chordTwo = manager["sus2"].Clone() as Chord;
            Chord chordThree = manager["sus4"].Clone() as Chord;
        }
    }

    // abstracts
    abstract class ChordPrototype
    {
        public abstract ChordPrototype Clone();
    }

    // concretes
    class Chord : ChordPrototype

    {
        private int _firstInterval;
        private int _secondInterval;
        private int _thirdInterval;

        // Constructor

        public Chord(int firstInterval, int secondInterval, int thirdInterval)
        {
            this._firstInterval = firstInterval;
            this._secondInterval = secondInterval;
            this._thirdInterval = thirdInterval;
        }

        // Create a shallow copy

        public override ChordPrototype Clone()
        {
            Console.WriteLine(
              "Cloning chord intervals: {0,3},{1,3},{2,3}",
              _firstInterval, _secondInterval, _thirdInterval);

            return this.MemberwiseClone() as ChordPrototype;
        }
    }
    class ChordManager
    {
        private Dictionary<string, ChordPrototype> _chords =
          new Dictionary<string, ChordPrototype>();

        // Indexer

        public ChordPrototype this[string key]
        {
            get { return _chords[key]; }
            set { _chords.Add(key, value); }
        }
    }


}