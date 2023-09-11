using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units
{
    public class ChessKnightMoves : ChessUnitMoves
    {
        private readonly List<ChessUnitMoveDirection> _directions = new()
            {
                { ChessUnitMoveDirection.TOP }, { ChessUnitMoveDirection.TOP_RIGHT }, { ChessUnitMoveDirection.RIGHT },
                { ChessUnitMoveDirection.BOTTOM_RIGHT }, { ChessUnitMoveDirection.BOTTOM },
                { ChessUnitMoveDirection.BOTTOM_LEFT }, { ChessUnitMoveDirection.LEFT }, { ChessUnitMoveDirection.TOP_LEFT },
            };
        private readonly int _countSteps = 1;

        public ChessKnightMoves()
        {
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves()
        {
            return CreateMovesForUnit(_directions, _countSteps, true);
        }
    }
}
