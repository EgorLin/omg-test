using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves.Units
{
    public class ChessPawnMoves : ChessUnitMoves, IChessUnitMovesProvider
    {
        private readonly List<ChessUnitMoveDirection> _directions;
        private readonly int _countSteps = 1;

        public ChessPawnMoves(ChessUnitColor color)
        {
            if (color == ChessUnitColor.Black)
                _directions = new List<ChessUnitMoveDirection>() { { ChessUnitMoveDirection.BOTTOM } };
            else
                _directions = new List<ChessUnitMoveDirection>() { { ChessUnitMoveDirection.TOP } };
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves()
        {
            return CreateMovesForUnit(_directions, _countSteps);
        }
    }
}
