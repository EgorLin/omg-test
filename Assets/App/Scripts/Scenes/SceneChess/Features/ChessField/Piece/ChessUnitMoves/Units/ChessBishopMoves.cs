using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units
{
    public class ChessBishopMoves : ChessUnitMoves, IChessUnitMovesProvider
    {
        private readonly List<ChessUnitMoveDirection> _directions = new()
            {
                { ChessUnitMoveDirection.TOP_RIGHT }, { ChessUnitMoveDirection.BOTTOM_RIGHT },
                { ChessUnitMoveDirection.BOTTOM_LEFT }, { ChessUnitMoveDirection.TOP_LEFT },
            };
        private readonly int _countSteps;

        public ChessBishopMoves()
        {
            _countSteps = _maxCountSteps;
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves()
        {
            return CreateMovesForUnit(_directions, _countSteps);
        }
    }
}
