using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Building.Services.Grid
{
    public interface IGridService
    {
        MapTile GetTileByWorldPosition(Vector3 worldPosition);
        IReadOnlyList<TileElementType> GetElementTypesInTile(Vector3 worldPosition);
        IReadOnlyList<ObjectType> GetObjectTypesInTile(Vector3 worldPosition);
        bool CanBuildInPosition(Vector3 at, Vector2Int size, List<TileElementType> elementTypesWhichBlock = null);
    }
}