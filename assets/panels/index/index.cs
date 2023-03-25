using Godot;
using Microsoft.Extensions.DependencyInjection;

namespace Akko.UI
{
	using API.AssetServer;

	public partial class index : Panel
	{
		HBoxContainer menuBar;
		TabContainer rightTab;
		
		public override void _Ready()
		{
			menuBar = GetNode<HBoxContainer>("VBoxContainer/TopBar/Menu");
			rightTab = GetNode<TabContainer>("VBoxContainer/Layout/Right/Top");
			
			var assetServer = App.Provider.GetService<IAssetServer>();
			var console = (PackedScene)assetServer.Load(PanelConst.Panel[EPanel.Console]);
			var child = console.Instantiate();
			rightTab.AddChild(child);
			
			CreateMenu(menuBar);
		}

		void CreateMenu(HBoxContainer root)
		{
			// foreach (var kv in Const.Command)
			// {
			// 	var cmd = kv.Key;
			// 	MenuButton menuButton = new MenuButton();
			// 	menuButton.Name = cmd.ToString();
			// 	menuButton.Text = cmd.ToString();
			// 	var popMenu = menuButton.GetPopup(); 
			// 	popMenu.AddItem("menu_1", 5, Key.A);
			// 	popMenu.IndexPressed += index => { GD.Print("press!: "+ index);};
			// 	popMenu.IdPressed += index => { GD.Print("press!: "+ index);};
			// 	// menuButton.Connect()
			// 	// popMenu.Connect()
			// 	
			// 	PopupMenu subMenuButton = new PopupMenu();
			// 	subMenuButton.Name = "456";
			// 	// var subPopMenu = subMenuButton.GetPopup(); 
			// 	// subPopMenu.AddItem("kkk");
			// 	subMenuButton.AddItem("sub_1");
			// 	subMenuButton.AddItem("sub_2");
			// 	// menuButton.AddChild(subMenuButton);
			//
			// 	popMenu.AddChild(subMenuButton);
			// 	popMenu.AddSubmenuItem(subMenuButton.Name, subMenuButton.Name);
			//
			//
			// 	// menuButton.
			// 	root.AddChild(menuButton);
			// 	// root.AddChild(subMenuButton);
			// }
			
			
		}


		public void _on_start_button_up()
		{
			GD.Print("Start!");
			var console = GetNode<VBoxContainer>("Console");
		}

		public void _on_start_2_button_up()
		{
			// Logger.Info("5555");
		}


	}
}
