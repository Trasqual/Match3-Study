using System.Collections.Generic;
using UnityEngine;

public class PieceCreator : Singleton<PieceCreator>
{
    [SerializeField] PieceBase piecePrefab;

    [SerializeField] Sprite redPiece;
    [SerializeField] Sprite greenPiece;
    [SerializeField] Sprite bluePiece;
    [SerializeField] Sprite yellowPiece;

    private Dictionary<PieceType, Sprite> regularPieceSprites = new();

    protected override void Awake()
    {
        base.Awake();
        regularPieceSprites[PieceType.Red] = redPiece;
        regularPieceSprites[PieceType.Green] = greenPiece;
        regularPieceSprites[PieceType.Blue] = bluePiece;
        regularPieceSprites[PieceType.Yellow] = yellowPiece;
    }

    private Sprite GetSprite(PieceType pieceType)
    {
        return regularPieceSprites[pieceType];
    }
}
