using Cinemachine;

namespace Prototype.Camera
{
    public interface IFocusable
    {
        void Focus(CameraMover cam);
        void EndFocus(CameraMover cam);
    }
}
