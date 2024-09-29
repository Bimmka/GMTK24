using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Building.Services.Grid
{
    public class GridService : IGridService
    {
        private Dictionary<Vector2Int, MapTile> _tiles;

        public MapTile GetTileByWorldPosition(Vector3 worldPosition)
        {
            throw new Exception("Implement this method");
        }

        public IReadOnlyList<TileElementType> GetElementTypesInTile(Vector3 worldPosition)
        {
            throw new Exception("Implement this method");
        }
        
        public IReadOnlyList<ObjectType> GetObjectTypesInTile(Vector3 worldPosition)
        {
            throw new Exception("Implement this method");
        }

        public bool CanBuildInPosition(Vector3 at, Vector2Int size, List<TileElementType> elementTypesWhichBlock = null)
        {
            return true;
        }
    }
}