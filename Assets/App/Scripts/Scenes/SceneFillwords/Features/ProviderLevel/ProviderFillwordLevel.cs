using System;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Assets.App.Scripts.Consts.Fillwords;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        public GridFillWords LoadModel(int index)
        {
            try
            {
                var wordsAndLettersNumbers = GetWordsAndLettersNumbers(index, FillwordsResourcePaths.levels);

                var lettersList = GetLettersList(wordsAndLettersNumbers, FillwordsResourcePaths.wordsList);
               
                var vectorSize = Convert.ToInt32(Math.Sqrt(lettersList.Length));
                Vector2Int size = new Vector2Int(vectorSize, vectorSize);

                var gridFillWords = new GridFillWords(size);
                FillGrid(lettersList, gridFillWords);

                return gridFillWords;
            } catch (Exception)
            {
                return null;
            }
        }

        private Dictionary<int, int[]> GetWordsAndLettersNumbers(int levelIndex, string path)
        {
            var wordsNumbers = new Dictionary<int, int[]>();
            var file = Resources.Load<TextAsset>(path);

            var lines = file.text.Split('\n');
            var line = lines[levelIndex];

            var values = line.Split(' ');
            for (var j = 0; j < values.Length; j += 2)
            {
                var wordNumber = int.Parse(values[j]);
                var lettersList = Array.ConvertAll(
                        values[j + 1].Split(';'),
                        s => int.Parse(s)
                    );
                wordsNumbers.Add(wordNumber, lettersList);
            }
            return wordsNumbers;
        }

        private string GetLettersList(Dictionary<int, int[]> wordsAndLettersNumbers, string path)
        {
            var wordsList = new StringBuilder();
            var file = Resources.Load<TextAsset>(path);

            var wordsListParsed = file.text.Split('\n');
            foreach (KeyValuePair<int, int[]> numberAndLettersWordPair in wordsAndLettersNumbers)
            {
                string word = wordsListParsed[numberAndLettersWordPair.Key];

                foreach (int letterNumber in numberAndLettersWordPair.Value)
                {
                    wordsList.Append(word[letterNumber]);
                }
            }

            return wordsList.ToString();
        }

        private GridFillWords FillGrid(string fillFrom, GridFillWords grid)
        {
            var currentLetterNumber = 0;
            for (var i = 0; i < grid.Size.x; i++)
            {
                for (var j = 0; j < grid.Size.y; j++)
                {
                    if (currentLetterNumber >= fillFrom.Length)
                    {
                        throw new Exception("Letters more than cells");
                    }
                    var c = new CharGridModel(fillFrom[currentLetterNumber]);
                    grid.Set(i, j, c);
                    currentLetterNumber++;
                }
            }
            return grid;
        }
    }
}