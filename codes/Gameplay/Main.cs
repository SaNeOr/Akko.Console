using Godot;
using Akko.API.AssetServer;
using Microsoft.Extensions.DependencyInjection;

namespace Akko.Gameplay
{
	using UI;

	public partial class Main : Node
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			GD.Print("Main");
			var assetServer = App.Provider.GetService<IAssetServer>();
			var scene = (PackedScene)assetServer.Load(PanelConst.Panel[EPanel.Index]);
			var child = scene.Instantiate();
			this.AddChild(child);
		}
	}
}