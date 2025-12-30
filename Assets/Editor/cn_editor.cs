public static class cn_editor
{
    [UnityEditor.InitializeOnLoadMethod]
    static void EditorInit()
    {
        UnityEditor.EditorApplication.update -= OnEditorUpdate;
        UnityEditor.EditorApplication.update += OnEditorUpdate;
    }

    static void OnEditorUpdate()
    {
        ++cn.EditorFrameCount;
    }
}
