using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Util;
using System.IO;
using System;
using Android.Content.Res;
using Android.Media;



// set Permissions in Manifest:
//	<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
//	<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
// ALSO on device: Settings/Apps/ListFileCopy_0 Permissions:Storage


// ListView_1 creates a Custom Adapter for lists of single lines of text.
// If we want more than one line of text we have to create a Custom Row.
// A Custom Row is a layout: we create custom_row.axml in Resources/layout.
// Implement the Custom Row in MyAdapter GetView() method.

// Steps for Custom Row:
// 1) design Custom Row in axml file under Rwsources/layout
// 2) in GetView method in custom adapter, inflate Custom Row you designed
//    view = context.LayoutInflater.Inflate(Resource.Layout.custom_row, null);
// 3) Find views you want to populate with data
// 4) Populate them
//    view.FindViewById<TextView>(Resource.Id.textViewCustomRow).Text = item;


// Create a custom adapter: MyAdapter class
// Custom Adapter works the same as SimpleListItem1 from ListView_0
// but now can add code for changing rows for ads/purchase


namespace BepoSoundsAnd_0
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		string[] soundFiles = {"bepoHello", "bepoCooCoo", "bepoGoool",
				"bepoHaveANiceDay", "bepoOhMan", "bepoOoooo", "bepoOops1",
				"bepoOops2", "bepoOopsyDaisy", "bepoPaparap", "bepoRooster",
				"bepoShoot", "bepoSleepyHead", "bepoWakyWaky", "bepoWolves"};

		//public CustomRowViewHolder holder;
		//MediaPlayer player;

		MyAdapter adapter;



		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			// create data set for listview

/*			string[] soundFiles = {"bepoHello.mp3", "bepoCooCoo.mp3", "bepoGoool.mp3",
				"bepoHaveANiceDay.mp3", "bepoOhMan.mp3", "bepoOoooo.mp3", "bepoOops1.mp3",
				"bepoOops2.mp3", "bepoOopsyDaisy.mp3", "bepoPaparap.mp3", "bepoRooster.mp3",
				"bepoShoot.mp3", "bepoSleepyHead.mp3", "bepoWakyWaky.mp3", "bepoWolves.mp3"};*/


			var data = new List<string>(soundFiles);

			// reference listView with layout resource
			var listView = FindViewById<ListView>(Resource.Id.listView1);
			listView.FastScrollEnabled = true;  // enable vertical scrollbar 


			//viewHolder = new CustomRowViewHolder();


			// create custom adapter and apply it to listView
			//var adapter = new MyAdapter(this, data);
			adapter = new MyAdapter(this, data);
			//var adapter = new MyAdapter(this, data, viewHolder);
			listView.Adapter = adapter;




			//holder = adapter.viewHolder;
			//holder.btnPlay.Click += OnBtnPlayClick;


		}

		protected override void OnPause() // if App goes in the background, stop playing the sound
		{
			base.OnPause();

			if (adapter.player != null && adapter.player.IsPlaying) {
				adapter.playerStop(); // stops and unloads the audio file: when app resumes, clicking the btn plays sound normally
											 //adapter.player.Pause();  // just pauses the the playing.  When app resumes, the audio resumes where it left off
			}
		}


		/*		private void OnBtnPlayClick(object sender, EventArgs e)
				{
					var position = (int)(sender as Button).Tag;

					Toast.MakeText(this, "Play at row: " + position, ToastLength.Short).Show();

					if (player == null)
						player = MediaPlayer.Create(this, Resource.Raw.ringbepo2);
					if (player.IsPlaying)
						player.Pause();  // stop() ???
					player.Start();

				}*/

	}
}

