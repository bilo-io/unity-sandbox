using MetaBuddy.UI.Styles;
using UnityEngine;

namespace MetaBuddy.UI.ErrorRow.Styles
{
    public class ErrorRow : IStyleFactory
    {
        private readonly Color _backgroundColor;

        public ErrorRow(Color backgroundColor)
        {
            _backgroundColor = backgroundColor;
        }

        public GUIStyle Create()
        {
            return StyleFactory.CreateBackground(_backgroundColor);
        }
    }
}
