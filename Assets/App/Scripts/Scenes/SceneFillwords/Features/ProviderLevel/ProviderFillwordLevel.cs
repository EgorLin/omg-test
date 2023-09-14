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

                int totalCountLetters = CountTotalLetters(wordAndLettersPairsIndexes);
                var vectorSize = Convert.ToInt32(Math.Sqrt(totalCountLetters));
                var indexAndLetterPairs = GetIndexAndLetterPairs(wordAndLettersPairsIndexes, FillwordsResourcePaths.wordsList, vectorSize * vectorSize);

                var gridSize = new Vector2Int(vectorSize, vectorSize);
                var gridFillWords = CreateGrid(gridSize, indexAndLetterPairs);

                return gridFillWords;
            }
            catch (Exception)
            {
                Debug.Log($"Failed to load {index} level");
                return null;
            }
        }

        internal Dictionary<int, int[]> GetWordsAndLettersIndexes(int levelIndex, string path)
        {
            var wordsAndLettersPairIndexes = new Dictionary<int, int[]>();

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

        private int CountTotalLetters(Dictionary<int, int[]> wordAndLettersPairsIndexes)
        {
            int totalCountLetters = 0;
            foreach (var word in wordAndLettersPairsIndexes.Values)
            {
                totalCountLetters += word.Length;
            }
            return totalCountLetters;
        }

        private Dictionary<int, char> GetIndexAndLetterPairs(Dictionary<int, int[]> wordAndLetterPairsIndexes, string path, int countCells)
        {
            var indexAndLetterPairs = new Dictionary<int, char>();

            var wordListParsed = FileManager.GetFile<TextAsset>(path).text.Split('\n');
            foreach ((int wordIndex, int[] letterIndexList) in wordAndLetterPairsIndexes)
            {
                ValidateWordIndex(wordIndex, wordListParsed);

                string originalWord = wordListParsed[wordIndex].Trim();
                ValidateWordLength(originalWord.Length, letterIndexList.Length);

                for (int i = 0; i < letterIndexList.Length; i++)
                {
                    var indexPositionInGrid = letterIndexList[i];
                    ValidateCellIndex(indexPositionInGrid, countCells);

                    if (!indexAndLetterPairs.TryAdd(indexPositionInGrid, originalWord[i]))
                        throw new Exception("The index of position already exists");
                }
            }

            ValidateLetterAndCellCount(countCells, indexAndLetterPairs.Count);

            return indexAndLetterPairs;
        }

        private GridFillWords CreateGrid(Vector2Int gridSize, Dictionary<int, char> indexAndLetterPairs)
        {
            var gridFillWords = new GridFillWords(gridSize);
            var currentCellNumber = 0;

            for (var i = 0; i < gridSize.x; i++)
            {
                for (var j = 0; j < gridSize.y; j++)
                {
                    var c = new CharGridModel(indexAndLetterPairs[currentCellNumber++]);
                    gridFillWords.Set(i, j, c);
                }
            }
            return gridFillWords;
        }

        private void ValidateWordIndex(int wordIndex, string[] wordListParsed)
        {
            if (wordIndex >= wordListParsed.Length)
            {
                throw new Exception("Index of looking for word is greater than list of words");
            }
        }

        private void ValidateWordLength(int originalWordLength, int letterIndexListLength)
        {
            if (originalWordLength != letterIndexListLength)
            {
                throw new Exception("Count of indexes and word length are not equal");
            }
        }

        private void ValidateCellIndex(int indexPositionInGrid, int countCells)
        {
            if (indexPositionInGrid >= countCells)
            {
                throw new Exception("The index of cell for letter is greater than the count of cells");
            }
        }

        private void ValidateLetterAndCellCount(int countCells, int letterAndCellCount)
        {
            if (countCells != letterAndCellCount)
            {
                throw new Exception("Number of cells are not equal to number of letters");
            }
        }
    }
}