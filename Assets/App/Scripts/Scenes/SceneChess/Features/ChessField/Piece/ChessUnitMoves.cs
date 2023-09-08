using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Scenes.SceneChess.Features.ChessField.Piece
{
    public class ChessUnitMoves
    {
        private Dictionary<ChessUnitMoveDirection, List<Vector2Int>> _movements;

        public ChessUnitMoves(ChessUnitType type, ChessUnitColor color)
        {
            _movements = GetMoves(type, color);
        }

        public Dictionary<ChessUnitMoveDirection, List<Vector2Int>> Movements { get => _movements; }

        private Dictionary<ChessUnitMoveDirection, List<Vector2Int>> GetMoves(ChessUnitType type, ChessUnitColor color)
        {
            var _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>();
            switch (type)
            {
                case ChessUnitType.Pon:
                    if (color == ChessUnitColor.Black)
                        _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>()
                        {
                            {
                                ChessUnitMoveDirection.BOTTOM, new List<Vector2Int>() { new Vector2Int(0, -1) }
},
                        };
                    else
                        _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>()
                        {
                            {
                                ChessUnitMoveDirection.TOP, new List<Vector2Int>() { new Vector2Int(0, 1) }
                            },
                        };
                    break;
                case ChessUnitType.King:
                    _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>()
                    {
                        {
                            ChessUnitMoveDirection.TOP, new List<Vector2Int>() { new Vector2Int(0, 1) }
                        },
                        {
                            ChessUnitMoveDirection.TOP_RIGHT, new List<Vector2Int>() { new Vector2Int(1, 1) }
                        },
                        {
                            ChessUnitMoveDirection.RIGHT, new List<Vector2Int>() { new Vector2Int(1, 0) }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM_RIGHT, new List<Vector2Int>() { new Vector2Int(1, -1) }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM, new List<Vector2Int>() { new Vector2Int(0, -1) }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM_LEFT, new List<Vector2Int>() { new Vector2Int(-1, -1) }
                        },
                        {
                            ChessUnitMoveDirection.LEFT, new List<Vector2Int>() { new Vector2Int(-1, 0) }
                        },
                        {
                            ChessUnitMoveDirection.TOP_LEFT, new List<Vector2Int>() { new Vector2Int(-1, 1) }
                        },
                    };
                    break;
                case ChessUnitType.Queen:
                    _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>()
                    {
                        {
                            ChessUnitMoveDirection.TOP, new List<Vector2Int>()
                            {
                                new Vector2Int(0, 1), new Vector2Int(0, 2), new Vector2Int(0, 3), new Vector2Int(0, 4), new Vector2Int(0, 5), new Vector2Int(0, 6), new Vector2Int(0, 7)
                            }
                        },
                        {
                            ChessUnitMoveDirection.TOP_RIGHT, new List<Vector2Int>()
                            {
                                new Vector2Int(1, 1), new Vector2Int(2, 2), new Vector2Int(3, 3), new Vector2Int(4, 4), new Vector2Int(5, 5), new Vector2Int(6, 6), new Vector2Int(7, 7)
                            }
                        },
                        {
                            ChessUnitMoveDirection.RIGHT, new List<Vector2Int>()
                            {
                                new Vector2Int(0, -1), new Vector2Int(0, -2), new Vector2Int(0, -3), new Vector2Int(0, -4), new Vector2Int(0, -5), new Vector2Int(0, -6), new Vector2Int(0, -7)
                            }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM_RIGHT, new List<Vector2Int>()
                            {
                                new Vector2Int(1, -1), new Vector2Int(2, -2), new Vector2Int(3, -3), new Vector2Int(4, -4), new Vector2Int(5, -5), new Vector2Int(6, -6), new Vector2Int(7, -7)
                            }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM, new List<Vector2Int>()
                            {
                                new Vector2Int(1, 0), new Vector2Int(2, 0), new Vector2Int(3, 0), new Vector2Int(4, 0), new Vector2Int(5, 0), new Vector2Int(6, 0), new Vector2Int(7, 0),
                            }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM_LEFT, new List<Vector2Int>()
                            {
                                new Vector2Int(-1, -1), new Vector2Int(-2, -2), new Vector2Int(-3, -3), new Vector2Int(-4, -4), new Vector2Int(-5, -5), new Vector2Int(-6, -6), new Vector2Int(-7, -7)
                            }
                        },
                        {
                            ChessUnitMoveDirection.LEFT, new List<Vector2Int>()
                            {
                                new Vector2Int(-1, 0), new Vector2Int(-2, 0), new Vector2Int(-3, 0), new Vector2Int(-4, 0), new Vector2Int(-5, 0), new Vector2Int(-6, 0), new Vector2Int(-7, 0)
                            }
                        },
                        {
                            ChessUnitMoveDirection.TOP_LEFT, new List<Vector2Int>()
                            {
                                new Vector2Int(-1, 1), new Vector2Int(-2, 2), new Vector2Int(-3, 3), new Vector2Int(-4, 4), new Vector2Int(-5, 5), new Vector2Int(-6, 6), new Vector2Int(-7, 7)
                            }
                        },
                    };
                    break;
                case ChessUnitType.Rook:
                    _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>()
                    {
                        {
                            ChessUnitMoveDirection.TOP, new List<Vector2Int>()
                            {
                                new Vector2Int(0, 1), new Vector2Int(0, 2), new Vector2Int(0, 3), new Vector2Int(0, 4), new Vector2Int(0, 5), new Vector2Int(0, 6), new Vector2Int(0, 7)
                            }
                        },
                        {
                            ChessUnitMoveDirection.RIGHT, new List<Vector2Int>()
                            {
                                new Vector2Int(1, 0), new Vector2Int(2, 0), new Vector2Int(3, 0), new Vector2Int(4, 0), new Vector2Int(5, 0), new Vector2Int(6, 0), new Vector2Int(7, 0)
                            }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM, new List<Vector2Int>()
                            {
                                new Vector2Int(0, -1), new Vector2Int(0, -2), new Vector2Int(0, -3), new Vector2Int(0, -4), new Vector2Int(0, -5), new Vector2Int(0, -6), new Vector2Int(0, -7)
                            }
                        },
                        {
                            ChessUnitMoveDirection.LEFT, new List<Vector2Int>()
                            {
                                new Vector2Int(-1, 0), new Vector2Int(-2, 0), new Vector2Int(-3, 0), new Vector2Int(-4, 0), new Vector2Int(-5, 0), new Vector2Int(-6, 0), new Vector2Int(-7, 0)
                            }
                        },
                    };
                    break;
                case ChessUnitType.Knight:
                    _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>()
                    {
                        {
                            ChessUnitMoveDirection.TOP, new List<Vector2Int>() { new Vector2Int(1, 2) }
                        },
                        {
                            ChessUnitMoveDirection.TOP_RIGHT, new List<Vector2Int>() { new Vector2Int(2, 1) }
                        },
                        {
                            ChessUnitMoveDirection.RIGHT, new List<Vector2Int>() { new Vector2Int(2, -1) }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM_RIGHT, new List<Vector2Int>() { new Vector2Int(1, -2) }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM, new List<Vector2Int>() { new Vector2Int(-1, -2) }
                        },
                        {
                            ChessUnitMoveDirection.BOTTOM_LEFT, new List<Vector2Int>() { new Vector2Int(-2, -1) }
                        },
                        {
                            ChessUnitMoveDirection.LEFT, new List<Vector2Int>() { new Vector2Int(-2, 1) }
                        },
                        {
                            ChessUnitMoveDirection.TOP_LEFT, new List<Vector2Int>() { new Vector2Int(-1, 2) }
                        },
                    };
                    break;
                case ChessUnitType.Bishop:
                    _moves = new Dictionary<ChessUnitMoveDirection, List<Vector2Int>>() {
                    {
                        ChessUnitMoveDirection.TOP_RIGHT, new List<Vector2Int>()
                        {
                            new Vector2Int(1, 1), new Vector2Int(2, 2), new Vector2Int(3, 3), new Vector2Int(4, 4), new Vector2Int(5, 5), new Vector2Int(6, 6), new Vector2Int(7, 7)
                        }
                    },
                    {
                        ChessUnitMoveDirection.BOTTOM_RIGHT, new List<Vector2Int>()
                        {
                            new Vector2Int(1, -1), new Vector2Int(2, -2), new Vector2Int(3, -3), new Vector2Int(4, -4), new Vector2Int(5, -5), new Vector2Int(6, -6), new Vector2Int(7, -7)
                        }
                    },
                    {
                        ChessUnitMoveDirection.BOTTOM_LEFT, new List<Vector2Int>()
                        {
                            new Vector2Int(-1, -1), new Vector2Int(-2, -2), new Vector2Int(-3, -3), new Vector2Int(-4, -4), new Vector2Int(-5, -5), new Vector2Int(-6, -6), new Vector2Int(-7, -7)
                        }
                    },
                    {
                        ChessUnitMoveDirection.TOP_LEFT, new List<Vector2Int>()
                        {
                            new Vector2Int(-1, 1), new Vector2Int(-2, 2), new Vector2Int(-3, 3), new Vector2Int(-4, 4), new Vector2Int(-5, 5), new Vector2Int(-6, 6), new Vector2Int(-7, 7)
                        }
                    },
                };
                    break;
            }
            return _moves;
        }
    }
}