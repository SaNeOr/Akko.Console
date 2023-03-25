using Akko.API.AssetServer;
using Godot;

namespace Akko.Impl.AssetServer;

public class AssetServer: IAssetServer
{
    public Resource Load(string path)
    {
        return ResourceLoader.Load(path);
    }
}