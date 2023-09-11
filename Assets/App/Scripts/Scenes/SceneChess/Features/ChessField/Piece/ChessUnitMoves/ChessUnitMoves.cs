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
        private readonly Dictionary<ChessUnitMoveDirection, Vector2Int> _directionMap = new()
        {
            { ChessUnitMoveDirection.TOP, new Vector2Int(0, 1) },
            { ChessUnitMoveDirection.TOP_RIGHT, new Vector2Int(1, 1) },
            { ChessUnitMoveDirection.RIGHT, new Vector2Int(1, 0) },
            { ChessUnitMoveDirection.BOTTOM_RIGHT, new Vector2Int(1, -1) },
            { ChessUnitMoveDirection.BOTTOM, new Vector2Int(0, -1) },
            { ChessUnitMoveDirection.BOTTOM_LEFT, new Vector2Int(-1, -1) },
            { ChessUnitMoveDirection.LEFT, new Vector2Int(-1, 0) },
            { ChessUnitMoveDirection.TOP_LEFT, new Vector2Int(-1, 1) },
        };
        protected static int _maxCountSteps;

        public static void Initialize(int chessGridSize)
        {
            _maxCountSteps = chessGridSize - 1;
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> Create(ChessUnitType type, ChessUnitColor color)
        {
            return type switch
            {
                ChessUnitType.Pon => new ChessPawnMoves(color).GetMoves(),
                ChessUnitType.King => new ChessKingMoves().GetMoves(),
                ChessUnitType.Queen => new ChessQueenMoves().GetMoves(),
                ChessUnitType.Rook => new ChessRookMoves().GetMoves(),
                ChessUnitType.Knight => new ChessKnightMoves().GetMoves(),
                ChessUnitType.Bishop => new ChessBishopMoves().GetMoves(),
                _ => throw new ArgumentException("Invalid ChessUnitType provided."),
            };
        }

        protected Dictionary<ChessUnitMoveDirection, List<Vector2Int>> CreateMovesForUnit(
            List<ChessUnitMoveDirection> directions, int countStepsPerDirection, bool isKnight = false
        )
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

        private List<Vector2Int> CreateDirectionMoves(Vector2Int direction, int countSteps)
        {
            var moves = new List<Vector2Int>();

            for (var i = 1; i <= countSteps; i++)
            {
                Vector2Int move = direction * i;
                moves.Add(move);
            }

            return moves;
        }

        private List<Vector2Int> CreateKnightDirectionMove(ChessUnitMoveDirection direction)
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

        private bool ParseNumberBitToBool(int number, int position)
        {
            return GetBit(number, position) == 1;
        }

        private int GetBit(int number, int position)
        {
            return (number >> position) & 1;
        }
    }
}