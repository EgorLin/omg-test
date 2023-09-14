using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ChessGridNavigatorTests
    {
        [Test]
        public void FindPath_PonType_ReturnsCorrectPath()
        {
            var pieceType = ChessUnitType.Pon;
            var start = new Vector2Int(2, 2);
            var destination = new Vector2Int(2, 4);

            var grid = CreateGridWithUnit(pieceType, start);
            var navigator = new ChessGridNavigator();

            var path = navigator.FindPath(pieceType, start, destination, grid);

            Assert.IsNotNull(path);
            Assert.AreEqual(2, path.Count);
            Assert.AreEqual(new Vector2Int(2, 3), path[0]);
            Assert.AreEqual(destination, path[1]);
        }

        [Test]
        public void FindPath_InvalidStartPosition_ReturnsNull()
        {
            var start = new Vector2Int(2, 2);
            var destination = new Vector2Int(2, 4);

            var grid = new ChessGrid(new Vector2Int(8, 8));
            var navigator = new ChessGridNavigator();

            var path = navigator.FindPath(ChessUnitType.Pon, start, destination, grid);

            Assert.IsNull(path);
        }

        [Test]
        public void FindPath_SameStartAndDestination_ReturnsEmptyPath()
        {
            var pieceType = ChessUnitType.Pon;
            var start = new Vector2Int(2, 2);
            var destination = new Vector2Int(2, 2);

            var grid = CreateGridWithUnit(pieceType, start);
            var navigator = new ChessGridNavigator();

            var path = navigator.FindPath(pieceType, start, destination, grid);

            Assert.IsNotNull(path);
            Assert.IsEmpty(path);
        }

        [Test]
        public void FindPath_BlockedPath_ReturnsLongerPath()
        {
            var pieceType = ChessUnitType.Rook;
            var start = new Vector2Int(2, 2);
            var destination = new Vector2Int(2, 4);

            var grid = CreateGridWithUnit(pieceType, start);
            var navigator = new ChessGridNavigator();

            var blockingPiece = new ChessPieceModel(ChessUnitType.Queen, ChessUnitColor.Black);
            var blockingUnit = new ChessUnit(blockingPiece);
            grid.SetAt(new Vector2Int(2, 3), blockingUnit);

            var path = navigator.FindPath(pieceType, start, destination, grid);

            Assert.IsNotNull(path);

            Assert.AreNotEqual(1, path.Count);
            Assert.AreNotEqual(destination, path[0]);

            Assert.AreEqual(3, path.Count);
            Assert.AreEqual(new Vector2Int(3, 2), path[0]);
            Assert.AreEqual(new Vector2Int(3, 4), path[1]);
            Assert.AreEqual(destination, path[2]);
        }

        public ChessGrid CreateGridWithUnit(ChessUnitType unitType, Vector2Int start)
        {
            var grid = new ChessGrid(new Vector2Int(8, 8));

            var piece = new ChessPieceModel(unitType, ChessUnitColor.White);
            var unit = new ChessUnit(piece);
            grid.SetAt(start, unit);

            return grid;
        }
    }
}
