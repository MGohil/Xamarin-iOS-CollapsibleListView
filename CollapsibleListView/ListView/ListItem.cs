using System;
using System.Collections.Generic;

namespace CollapsibleListView
{
	public class ListItem
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string SelectedStateIcon { get; set; }

		public string DeselectedStateIcon { get; set; }

		public bool IsSelected { get; set; }

		public List<ListItem> ChildItems { get; set; }

		public Action<ListItem> OnClickListener { get; set; }
	}
}

