using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units
{
    public class ChessBishopMoves : ChessUnitMoves, IChessUnitMovesProvider
    {
        private readonly List<ChessUnitMoveDirection> _directions = new()
            {
                { ChessUnitMoveDirection.TopRight }, { ChessUnitMoveDirection.BottomRight },
                { ChessUnitMoveDirection.BottomLeft }, { ChessUnitMoveDirection.TopLeft },
            };
        private readonly int _countSteps;

        public ChessBishopMoves(int chessGridSize) : base(chessGridSize)
        {
            _countSteps = chessGridSize - 1;
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves()
        {
            return CreateMovesForUnit(_directions, _countSteps);
        }
    }
}
