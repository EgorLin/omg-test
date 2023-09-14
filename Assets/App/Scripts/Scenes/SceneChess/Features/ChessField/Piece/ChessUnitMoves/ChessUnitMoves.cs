using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units;
using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves
{
    public class ChessUnitMoves
    {
        private static readonly Dictionary<ChessUnitMoveDirection, Vector2Int> _directionMap = new()
        {
            { ChessUnitMoveDirection.Top, new Vector2Int(0, 1) },
            { ChessUnitMoveDirection.TopRight, new Vector2Int(1, 1) },
            { ChessUnitMoveDirection.Right, new Vector2Int(1, 0) },
            { ChessUnitMoveDirection.BottomRight, new Vector2Int(1, -1) },
            { ChessUnitMoveDirection.Bottom, new Vector2Int(0, -1) },
            { ChessUnitMoveDirection.BottomLeft, new Vector2Int(-1, -1) },
            { ChessUnitMoveDirection.Left, new Vector2Int(-1, 0) },
            { ChessUnitMoveDirection.TopLeft, new Vector2Int(-1, 1) },
        };

        protected int _chessGridSize;

        public ChessUnitMoves(int chessGridSize)
        {
            _chessGridSize = chessGridSize;
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> Create(ChessUnitType type, ChessUnitColor color)
        {
            return type switch
            {
                ChessUnitType.Pon => new ChessPawnMoves(_chessGridSize, color).GetMoves(),
                ChessUnitType.King => new ChessKingMoves(_chessGridSize).GetMoves(),
                ChessUnitType.Queen => new ChessQueenMoves(_chessGridSize).GetMoves(),
                ChessUnitType.Rook => new ChessRookMoves(_chessGridSize).GetMoves(),
                ChessUnitType.Knight => new ChessKnightMoves(_chessGridSize).GetMoves(),
                ChessUnitType.Bishop => new ChessBishopMoves(_chessGridSize).GetMoves(),
                _ => throw new ArgumentException("Invalid ChessUnitType provided."),
            };
        }

        protected static Dictionary<ChessUnitMoveDirection, List<Vector2Int>> CreateMovesForUnit(
            List<ChessUnitMoveDirection> directions, int countStepsPerDirection, bool isKnight = false)
        {
            var unitMoves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>();

            foreach (var direction in directions)
            {
                if (!isKnight)
                {
                    unitMoves.Add(direction, CreateDirectionMoves(_directionMap[direction], countStepsPerDirection));
                }
                else
                {
                    unitMoves.Add(direction, CreateKnightDirectionMove(direction));
                }
            }

            return unitMoves;
        }

        private static List<Vector2Int> CreateDirectionMoves(Vector2Int direction, int countSteps)
        {
            var moves = new List<Vector2Int>();

            for (var i = 1; i <= countSteps; i++)
            {
                Vector2Int move = direction * i;
                moves.Add(move);
            }

            return moves;
        }

        private static List<Vector2Int> CreateKnightDirectionMove(ChessUnitMoveDirection direction)
        {
            // _ _ 0 0 first bits mean signs for two numbers 
            // XOR of last two bits means will it be reversed or won't
            // 1 0 _ _  = (2, 1)
            var baseMove = new Vector2Int(1, 2);
            int number = (int)direction;

            var flags = new bool[4].Select((_, index) => ParseNumberBitToBool(number, index)).ToArray();

            if (flags[3] ^ flags[2])
                baseMove = new Vector2Int(2, 1);
            if (flags[1])
                baseMove.x *= -1;
            if (flags[0])
                baseMove.y *= -1;

            return new List<Vector2Int>() { baseMove };
        }

        private static bool ParseNumberBitToBool(int number, int position)
        {
            return GetBit(number, position) == 1;
        }

        private static int GetBit(int number, int position)
        {
            return (number >> position) & 1;
        }
    }
}