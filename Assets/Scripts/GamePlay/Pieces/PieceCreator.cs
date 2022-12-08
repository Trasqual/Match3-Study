using System.Collections.Generic;
using UnityEngine;

public class PieceCreator : Singleton<PieceCreator>
{
    [SerializeField] Sprite redPiece;
    [SerializeField] Sprite greenPiece;
    [SerializeField] Sprite bluePiece;
    [SerializeField] Sprite yellowPiece;

    private Dictionary<PieceType, Sprite> pieceSprites = new();

    protected override void Awake()
    {
        base.Awake();
        pieceSprites[PieceType.Red] = redPiece;
        pieceSprites[PieceType.Green] = greenPiece;
        pieceSprites[PieceType.Blue] = bluePiece;
        pieceSprites[PieceType.Yellow] = yellowPiece;
    }

    public Sprite GetSprite(PieceType pieceType)
    {
        return pieceSprites[pieceType];
    }
}
