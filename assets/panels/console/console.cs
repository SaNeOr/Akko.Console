using System.Collections.Generic;
using Godot;

namespace Akko.UI
{
	using Akko.Framework.API.Logger;
	
	public partial class console : VBoxContainer
	{
		Tree tree;
		LineEdit filter;
		public List<string> Context = new();
		
		
		void BindingNode()
		{
			tree = GetNode<Tree>("Tree");
			filter = GetNode<LineEdit>("Filter/ConsoleFilter");
		}

		
		public override void _Ready()
		{
			BindingNode();
			ILogger.onRecLog -= HandleLog;
			ILogger.onRecLog += HandleLog;
		}
		
		public void _on_console_filter_text_changed(string _filter)
		{
			UpdateTree();
		}
		
		public void _on_clear_pressed()
		{
			tree.Clear();
			Context.Clear();
		}

		void AddItem(string content, string filterTxt = "")
		{
			if (content.Contains(filterTxt))
			{
				TreeItem item = tree.CreateItem();
				item.SetText(0, content);
			}
		}


		public void HandleLog(string message)
		{
			Context.Add(message);
			AddItem(message);
		}

		void UpdateTree()
		{
			var filterTxt = filter.Text;
			tree.Clear();
			tree.CreateItem();
		
			foreach (var ctx in Context)
			{
				AddItem(ctx, filterTxt);
			}
		}
	}
}