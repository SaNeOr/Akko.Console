using Godot;

namespace Akko.API.AssetServer
{

    public interface IAssetServer
    {
        Resource Load(string path);
    }
}