using App.Scripts.Libs.FileManager;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using Assets.App.Scripts.Scenes.SceneFillwords.Consts;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        public GridFillWords LoadModel(int index)
        {
            try
            {
                var wordAndLettersPairsIndexes = GetWordsAndLettersIndexes(index, FillwordsResourcePaths.levels);

                int totalCountLetters = 0;
                foreach (var word in wordAndLettersPairsIndexes)
                {
                    totalCountLetters += word.Value.Length;
                }
                var vectorSize = Convert.ToInt32(Math.Sqrt(totalCountLetters));
                var indexAndLetterPairs = GetIndexAndLetterPairs(wordAndLettersPairsIndexes, FillwordsResourcePaths.wordsList, vectorSize * vectorSize);

                var gridSize = new Vector2Int(vectorSize, vectorSize);

                var gridFillWords = new GridFillWords(gridSize);
                FillGrid(indexAndLetterPairs, gridFillWords);

                return gridFillWords;
            }
            catch (Exception)
            {
                Debug.Log("Failed to load " + index + " level");
                return null;
            }
        }

        private Dictionary<int, int[]> GetWordsAndLettersIndexes(int levelIndex, string path)
        {
            var wordsAndLettersPairIndexes = new Dictionary<int, int[]>();
            var file = Resources.Load<TextAsset>(path);

            var lines = FileManager.GetFile<TextAsset>(path).text.Split('\n');
            var level = lines[levelIndex];

            var wordsAndLettersIndexes = level.Split(' ');
            var countElementsToTake = 2;
            for (var j = 0; j < wordsAndLettersIndexes.Length; j += countElementsToTake)
            {
                var wordIndex = int.Parse(wordsAndLettersIndexes[j]);
                var lettersList = Array.ConvertAll(
                        wordsAndLettersIndexes[j + 1].Split(';'),
                        letter => int.Parse(letter)
                    );
                wordsAndLettersPairIndexes.Add(wordIndex, lettersList);
            }
            return wordsAndLettersPairIndexes;
        }

        private Dictionary<int, char> GetIndexAndLetterPairs(Dictionary<int, int[]> wordAndLettersPairsIndexes, string path, int countCells)
        {
            var indexAndLetterPairs = new Dictionary<int, char>();

            var wordListParsed = FileManager.GetFile<TextAsset>(path).text.Split('\n');
            foreach (KeyValuePair<int, int[]> wordAndLettersPair in wordAndLettersPairsIndexes)
            {
                if (wordAndLettersPair.Key >= wordListParsed.Length)
                    throw new Exception("Index of looking for word is greater than list of words");

                string originalWord = wordListParsed[wordAndLettersPair.Key].Trim();
                if (originalWord.Length != wordAndLettersPair.Value.Length)
                    throw new Exception("Count of indexes and word length are not equal");

                for (int i = 0; i < wordAndLettersPair.Value.Length; i++)
                {
                    var indexPositionInGrid = wordAndLettersPair.Value[i];
                    if (indexPositionInGrid >= countCells)
                        throw new Exception("The index of cell for letter is greater than the count of cells");
                    if (!indexAndLetterPairs.TryAdd(indexPositionInGrid, originalWord[i]))
                        throw new Exception("The index of position already exists");
                }
            }

            var areLettersAndCellsEqual = countCells == indexAndLetterPairs.Count;
            if (!areLettersAndCellsEqual)
                throw new Exception("Number of cells are not equal to number of letters");

            return indexAndLetterPairs;
        }

        private GridFillWords FillGrid(Dictionary<int, char> indexAndLetterPairs, GridFillWords grid)
        {
            var currentCellNumber = 0;
            for (var i = 0; i < grid.Size.x; i++)
            {
                for (var j = 0; j < grid.Size.y; j++)
                {
                    var c = new CharGridModel(indexAndLetterPairs[currentCellNumber++]);
                    grid.Set(i, j, c);
                }
            }
            return grid;
        }
    }
}