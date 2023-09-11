using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using System;
using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel
{
    public class FactoryLevelModel : IFactory<LevelModel, LevelInfo, int>
    {
        public LevelModel Create(LevelInfo value, int levelNumber)
        {
            try
            {
                var model = new LevelModel
                {
                    LevelNumber = levelNumber,
                    Words = value.words,
                    InputChars = BuildListChars(value.words)
                };

                return model;
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError(e.Message);
                return null;
            }
        }

        private List<char> BuildListChars(List<string> words)
        {
            var storeDict = new Dictionary<char, int>();
            words.ForEach(word =>
            {
                var tempDict = GetLettersFromWord(word);

                AddLetters(tempDict, storeDict);
            });

            var listChars = GetListChars(storeDict);

            return listChars;
        }

        private Dictionary<char, int> GetLettersFromWord(string word)
        {
            var tempDict = new Dictionary<char, int>();
            foreach (var letter in word)
            {
                if (tempDict.ContainsKey(letter))
                {
                    tempDict[letter] += 1;
                }
                else
                {
                    tempDict.Add(letter, 1);
                }
            }
            return tempDict;
        }

        private void AddLetters(Dictionary<char, int> from, Dictionary<char, int> to)
        {
            foreach ((char letter, int countLetter) in from)
            {
                if (!to.ContainsKey(letter))
                {
                    to.Add(letter, countLetter);
                }
                else if (countLetter > to[letter])
                {
                    to[letter] = countLetter;
                }
            }
        }

        private List<char> GetListChars(Dictionary<char, int> dictionary)
        {
            var listChars = new List<char>();
            foreach ((char letter, int countLetter) in dictionary)
            {
                for (var i = 0; i < countLetter; i++)
                {
                    listChars.Add(letter);
                }
            }
            return listChars;
        }
    }
}