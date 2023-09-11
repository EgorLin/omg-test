using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves;
using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class ChessGridNavigator : IChessGridNavigator
    {
        public List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int from, Vector2Int to, ChessGrid grid)
        {
            try
            {
                ChessUnitMoves.Initialize(grid.Size.x);
                var currentPiece = grid.Get(from).PieceModel;
                var unitMoves = new ChessUnitMoves().Create(currentPiece.PieceType, currentPiece.Color);

                var path = BFS(unitMoves, from, to, grid);

                return path;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return null;
            }
        }

        private bool IsInsideGrid(Vector2Int pos, Vector2Int gridSize)
        {
            if (pos.x >= 0 && pos.x < gridSize.x && pos.y >= 0 && pos.y < gridSize.y) return true;

            return false;
        }

        private bool[,] InitVisitedGrid(Vector2Int size)
        {
            var visitedGrid = new bool[size.x, size.y];

            for (var i = 0; i < size.x; ++i)
            {
                for (var j = 0; j < size.y; ++j)
                {
                    visitedGrid[i, j] = false;
                }
            }

            return visitedGrid;
        }

        private List<Vector2Int> BFS(Dictionary<ChessUnitMoveDirection, List<Vector2Int>> unitMoves,
            Vector2Int start, Vector2Int destination, ChessGrid grid)
        {
            var queue = new Queue<Vector2Int>();
            var parentRecords = new Dictionary<Vector2Int, Vector2Int>();
            var visitedGrid = InitVisitedGrid(grid.Size);

            visitedGrid[start.x, start.y] = true;

            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                var currentPos = queue.Dequeue();

                if (currentPos.x == destination.x && currentPos.y == destination.y)
                {
                    return GetBacktrace(parentRecords, start, destination);
                }

                foreach ((ChessUnitMoveDirection direction, List<Vector2Int> moves) in unitMoves)
                {
                    foreach (var move in moves)
                    {
                        var posToCheck = currentPos + move;
                        if (!IsInsideGrid(posToCheck, grid.Size))
                        {
                            continue;
                        }

                        var isVisited = visitedGrid[posToCheck.x, posToCheck.y];
                        if (isVisited)
                        {
                            continue;
                        }

                        var isCellEmpty = grid.Get(posToCheck) is null;
                        if (!isCellEmpty)
                        {
                            break;
                        }

                        queue.Enqueue(posToCheck);
                        parentRecords.Add(posToCheck, currentPos);
                        visitedGrid[posToCheck.x, posToCheck.y] = true;
                    }
                }
            }
            return null;
        }

        private List<Vector2Int> GetBacktrace(Dictionary<Vector2Int, Vector2Int> parentConnections, Vector2Int start, Vector2Int end)
        {
            var path = new List<Vector2Int> { end };

            var lastElement = path[0];
            while (lastElement != start)
            {
                var parent = parentConnections.GetValueOrDefault(lastElement, new Vector2Int());
                path.Add(parent);
                lastElement = path[path.Count - 1];
            }

            path.Remove(start);
            path.Reverse();

            return path;
        }
    }
}