using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units
{
    public class ChessRookMoves : ChessUnitMoves
    {
        private readonly List<ChessUnitMoveDirection> _directions = new()
        {
            { ChessUnitMoveDirection.TOP }, { ChessUnitMoveDirection.RIGHT },
            { ChessUnitMoveDirection.BOTTOM }, { ChessUnitMoveDirection.LEFT },
        };
        private readonly int _countSteps;

        public ChessRookMoves()
        {
            _countSteps = _maxCountSteps;
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves()
        {
            return CreateMovesForUnit(_directions, _countSteps);
        }
    }
}
