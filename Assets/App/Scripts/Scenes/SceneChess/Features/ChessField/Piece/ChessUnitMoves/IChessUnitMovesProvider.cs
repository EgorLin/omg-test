using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece.ChessUnitMoves
{
    public interface IChessUnitMovesProvider
    {
        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves();
    }
}