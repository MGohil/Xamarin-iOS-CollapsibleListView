using System;

using UIKit;
using System.Collections.Generic;

namespace CollapsibleListView
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		List<ListItem> items;
		CollapsibleListView cv;

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			//Fill settings in the setting ui
			if (items == null) {
				items = new List<ListItem> ();
				items.Add (new ListItem () {
					Id = 0,
					Title = "Parent Without Child",
					IsSelected = true,
					SelectedStateIcon = "switch_on.png",
					DeselectedStateIcon = "switch_off.png",
					OnClickListener = new Action<ListItem> ((s) => {
						
					})
				});

				items.Add (new ListItem () { 
					Id = 1,
					Title = "Parent #2",
					IsSelected = false,
					SelectedStateIcon = "arrow_up.png",
					DeselectedStateIcon = "arrow_down.png",
					ChildItems = new List<ListItem> () {
						new ListItem () { 
							Id = 0, 
							Title = "Child #1 [Switch]", 
							IsSelected = true, 
							SelectedStateIcon = "switch_on.png",
							DeselectedStateIcon = "switch_off.png",
						},
						new ListItem () { 
							Id = 1, 
							Title = "Child #2 [Switch]", 
							IsSelected = true, 
							SelectedStateIcon = "switch_on.png",
							DeselectedStateIcon = "switch_off.png",
						},
						new ListItem () { 
							Id = 2, 
							Title = "Child #3 [Switch]", 
							IsSelected = true, 
							SelectedStateIcon = "switch_on.png",
							DeselectedStateIcon = "switch_off.png",
						},
						new ListItem () { 
							Id = 3, 
							Title = "Child #4 [Switch]", 
							IsSelected = true, 
							SelectedStateIcon = "switch_on.png",
							DeselectedStateIcon = "switch_off.png",
						},
						new ListItem () { 
							Id = 4, 
							Title = "Child #5 [Switch]", 
							IsSelected = true, 
							SelectedStateIcon = "switch_on.png",
							DeselectedStateIcon = "switch_off.png",
						},

					}
				});

				items.Add (new ListItem () { 
					Id = 2,
					Title = "Parent #3",
					IsSelected = false,
					SelectedStateIcon = "arrow_up.png",
					DeselectedStateIcon = "arrow_down.png",
					OnClickListener = new Action<ListItem> ((s) => {						
						items [2].ChildItems.ForEach (x => x.IsSelected = false);
					}),
					ChildItems = new List<ListItem> () {
						new ListItem (){ Id = 0, Title = "Plain Text" },
						new ListItem () { 
							Id = 1, 
							Title = "Plain Text"
						}
					}
				});

				items.Add (new ListItem () { 
					Id = 3,
					Title = "Parent #4",
					IsSelected = false,
					SelectedStateIcon = "arrow_up.png",
					DeselectedStateIcon = "arrow_down.png",
					ChildItems = new List<ListItem> () {
						new ListItem (){ Id = 0, Title = "Plain Text" },
						new ListItem () { Id = 1, Title = "Click Action", OnClickListener = new Action<ListItem> ((s) => {								
								var alert = new UIAlertView ("Parent #4", "You clicked on Child #2", null, "OK");
								alert.Show ();
							})
						},
						new ListItem () { Id = 2, Title = "Click Action", OnClickListener = new Action<ListItem> ((s) => {
								var alert = new UIAlertView ("Parent #4", "You clicked on Child #3", null, "OK");
								alert.Show ();
							})
						},
						new ListItem (){ Id = 3, Title = "V " + "1.0" },

					}
				});


				cv = new CollapsibleListView (this.View.Frame);
				this.View.AddSubview (cv);
			}
			cv.ReloadData (items);


			AutomaticallyAdjustsScrollViewInsets = false;	
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

