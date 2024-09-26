using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Code.Editor.CustomEditors.LevelCreation
{
    public class LevelControlEditorWindow : OdinMenuEditorWindow
    {
        [MenuItem("Tools/Level Creation")]
        private static void OpenWindow()
        {
            GetWindow<LevelControlEditorWindow>().Show();
        }
        
        
        protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree();

            tree.AddAllAssetsAtPath("Level Configs", "Assets/Resources/Configs/LevelConfigs");
            tree.SortMenuItemsByName();
            
            return tree;
        }
    }
}