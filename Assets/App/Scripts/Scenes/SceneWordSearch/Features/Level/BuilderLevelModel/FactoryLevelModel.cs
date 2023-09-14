using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel
{
    public class FactoryLevelModel : IFactory<LevelModel, LevelInfo, int>
    {
        public LevelModel Create(LevelInfo value, int levelNumber)
        {
            try
            {
                ValidateInput(value);
                var levelModel = new LevelModel
                {
                    LevelNumber = levelNumber,
                    Words = value.words,
                    InputChars = BuildListOfChars(value.words)
                };

                return levelModel;
            }
            catch (Exception e)
            {
                Debug.Log($"Error creating LevelModel: {e.Message}");
                return null;
            }
        }

        private List<char> BuildListOfChars(List<string> words)
        {
            var commonCharFrequencyDictionary = new Dictionary<char, int>();

            foreach (var word in words)
            {
                var letterFrequencyDict = GetLetterFrequencyFromWord(word);
                AddLetterFrequencies(letterFrequencyDict, commonCharFrequencyDictionary);
            }

            var listOfChars = GetListOfChars(commonCharFrequencyDictionary);

            return listOfChars;
        }

        private Dictionary<char, int> GetLetterFrequencyFromWord(string word)
        {
            var letterFrequencyDict = new Dictionary<char, int>();

            foreach (var letter in word)
            {
                if (letterFrequencyDict.ContainsKey(letter))
                {
                    letterFrequencyDict[letter] += 1;
                }
                else
                {
                    letterFrequencyDict.Add(letter, 1);
                }
            }

            return letterFrequencyDict;
        }

        private void AddLetterFrequencies(Dictionary<char, int> from, Dictionary<char, int> to)
        {
            foreach (var (letter, frequency) in from)
            {
                if (!to.ContainsKey(letter))
                {
                    to.Add(letter, frequency);
                }
                else if (frequency > to[letter])
                {
                    to[letter] = frequency;
                }
            }
        }

        private List<char> GetListOfChars(Dictionary<char, int> dictionary)
        {
            return dictionary.SelectMany(pair => Enumerable.Repeat(pair.Key, pair.Value)).ToList();
        }

        private void ValidateInput(LevelInfo value)
        {
            if (value == null || value.words == null)
            {
                throw new ArgumentNullException("value", "LevelInfo or words list cannot be null.");
            }
        }
    }
}