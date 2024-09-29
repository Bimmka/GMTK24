using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Building.Services.Grid
{
    public class MapTile
    {
        public Vector2Int Position;
        public List<TileElementType> ElementTypes;
        public List<ObjectType> ObjectTypes;
    }
}