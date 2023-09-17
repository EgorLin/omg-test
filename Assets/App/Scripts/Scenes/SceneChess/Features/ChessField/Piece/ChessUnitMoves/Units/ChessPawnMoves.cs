using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units
{
    public class ChessPawnMoves : ChessUnitMoves, IChessUnitMovesProvider
    {
        private readonly List<ChessUnitMoveDirection> _directions = new()
            {
                { ChessUnitMoveDirection.Top }, { ChessUnitMoveDirection.Bottom }
            };
        private readonly int _countSteps = 1;

        public ChessPawnMoves(int chessGridSize) : base(chessGridSize)
        {
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves()
        {
            return CreateMovesForUnit(_directions, _countSteps);
        }
    }
}
