﻿using System; using System.Windows.Input; using Newtonsoft.Json; using Xamarin.Forms;  namespace Mafia { 	public class NightResultAdminViewsModel : ContentPage 	{ 		public ICommand StartPlay { get; set; } 		private readonly IGameService _gameService; //!! 		public int i; 		private Page _page;  		public NightResultAdminViewsModel(Page page, IGameService gameService) //!!
		{ 			var i = 0; 			_gameService = gameService; //!! 			_gameService.OnReceive += GameService_OnReceive; //!! 			StartPlay = new Command(OpenDayPage); 		}   		private void GameService_OnReceive(object sender, Message e) //принимает данные сервера
		{ 			Device.BeginInvokeOnMainThread(async () => 			{ 				if ((e.UserMessage == "Day") && (i == 0)) 				{ 					i++; 					var app = (App)Application.Current; // без вовзврата на  					app.MainPage = new NavigationPage(new DayPage()); // предыдущую страницу

				} 			}); 		}  		private async void OpenDayPage() 		{ 			var app = (App)Application.Current; // без вовзврата на  			app.MainPage = new NavigationPage(new DayPage()); // предыдущую страницу
		} 	} }   