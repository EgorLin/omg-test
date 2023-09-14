using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units
{
    public class ChessRookMoves : ChessUnitMoves, IChessUnitMovesProvider
    {
        private readonly List<ChessUnitMoveDirection> _directions = new()
        {
            { ChessUnitMoveDirection.Top }, { ChessUnitMoveDirection.Right },
            { ChessUnitMoveDirection.Bottom }, { ChessUnitMoveDirection.Left },
        };
        private readonly int _countSteps;

        public ChessRookMoves(int chessGridSize) : base(chessGridSize)
        {
            _countSteps = chessGridSize - 1;
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves()
        {
            return CreateMovesForUnit(_directions, _countSteps);
        }
    }
}
