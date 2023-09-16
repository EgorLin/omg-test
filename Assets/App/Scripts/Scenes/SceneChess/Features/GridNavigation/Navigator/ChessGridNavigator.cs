using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
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
                var currentPiece = grid.Get(from)?.PieceModel;
                ValidateCurrentPiece(currentPiece);

                var unitMoves = new ChessUnitMoves(grid.Size.x).Create(currentPiece.PieceType, currentPiece.Color);

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
            return pos.x >= 0 && pos.x < gridSize.x && pos.y >= 0 && pos.y < gridSize.y;
        }

        private List<Vector2Int> BFS(Dictionary<ChessUnitMoveDirection, List<Vector2Int>> unitMoves,
            Vector2Int start, Vector2Int destination, ChessGrid grid)
        {
            var queue = new Queue<Vector2Int>();
            var parentRecords = new Dictionary<Vector2Int, Vector2Int>();
            var visitedGrid = new bool[grid.Size.x, grid.Size.y];

            visitedGrid[start.x, start.y] = true;

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var currentPos = queue.Dequeue();

                if (currentPos == destination)
                {
                    return GetBacktrace(parentRecords, start, destination);
                }

                foreach (var (_, moves) in unitMoves)
                {
                    foreach (var move in moves)
                    {
                        var posToCheck = currentPos + move;
                        if (!IsInsideGrid(posToCheck, grid.Size) || visitedGrid[posToCheck.x, posToCheck.y])
                        {
                            continue;
                        }

                        // if it's not empty, then it doesn't make any sense to check positions in that direction
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
                var parent = parentConnections.GetValueOrDefault(lastElement);
                path.Add(parent);
                lastElement = path[^1];
            }

            path.Remove(start);
            path.Reverse();

            return path;
        }

        private void ValidateCurrentPiece(ChessPieceModel currentPiece)
        {
            if (currentPiece is null)
            {
                throw new Exception("No piece found at the starting position.");
            }
        }
    }
}